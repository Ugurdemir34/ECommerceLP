using ECommerceLP.Core.Abstraction.RemoteCall;
using ECommerceLP.Core.IOC;
using ECommerceLP.Core.RemoteCall.Settings;
using ECommerceLP.Core.Serialization.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace ECommerceLP.Core.RemoteCall.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddRemoteCall(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientFactory, ECommerceLP.Core.RemoteCall.HttpClientFactory.HttpClientFactory>();
            var xx = services.BuildServiceProvider();
            var configuration = xx.GetRequiredService<IConfiguration>();
            var svcs = configuration.GetSection("Service")
                .GetChildren()
                .AsEnumerable();

            var options = new RemoteCallServiceSettings();

            foreach (var service in svcs)
            {
                options.Add(service.Key, service.Get<RemoteCallServiceSetting>());
            }

            services.AddSingleton(typeof(IOptions<RemoteCallServiceSettings>), x =>
            {
                var configuration = x.GetRequiredService<IConfiguration>();
                var svcs = configuration.GetSection("Service")
                    .GetChildren()
                    .AsEnumerable();

                var options = new RemoteCallServiceSettings();

                foreach (var service in svcs)
                {
                    options.Add(service.Key, service.Get<RemoteCallServiceSetting>());
                }

                return options;
            });
            services.AddRemoteCallServices();
            return services;
        }
        private static void AddRemoteCallServices(this IServiceCollection services)
        {
            foreach (var abstractionAssembly in AssemblyDiscovery.GetInstance().CommonAssemblies)
            {
                foreach (var typeToRegister in abstractionAssembly.GetTypes().Where(x => typeof(IRemoteCallService).IsAssignableFrom(x) && x.IsInterface))
                {                  
                    services.AddTransient(typeToRegister, provider =>
                    {
                        var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                        var httpClient = httpClientFactory.CreateClient(typeToRegister.FullName);
                        var remoteCallClient = RestService.For(typeToRegister, httpClient,new RefitSettings()
                        {
                            ContentSerializer = new NewtonsoftJsonContentSerializer(new SerializerSettings())
                        });
                        return remoteCallClient;                       
                    });
                }
            }
        }
    }
}
