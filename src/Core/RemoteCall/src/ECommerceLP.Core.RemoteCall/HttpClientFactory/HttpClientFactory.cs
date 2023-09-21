using ECommerceLP.Core.Abstraction.RemoteCall;
using ECommerceLP.Core.IOC;
using ECommerceLP.Core.RemoteCall.HttpClientFactory.Inbound;
using ECommerceLP.Core.RemoteCall.Settings;
using ECommerceLP.Core.Serialization.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.RemoteCall.HttpClientFactory
{
    internal class HttpClientFactory : IHttpClientFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJSONSerializer _serializer;
        private readonly IOptions<RemoteCallServiceSettings> _serviceSettings;

        private static readonly ConcurrentDictionary<string, HttpClient> _httpClientsForRemoteCall;
        static HttpClientFactory()
        {
            _httpClientsForRemoteCall = new ConcurrentDictionary<string, HttpClient>();
        }
        public HttpClientFactory(IHttpContextAccessor httpContextAccessor, IJSONSerializer serializer, IOptions<RemoteCallServiceSettings> serviceSettings)
        {
            _httpContextAccessor = httpContextAccessor;
            _serializer = serializer;
            _serviceSettings = serviceSettings;
        }
        public HttpClient CreateClient(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new HttpClient();
            }
            var serviceType = this.GetServiceType(name);
            var serviceSettings = this.GetServiceSettings(serviceType);
            if (typeof(IRemoteCallService).IsAssignableFrom(serviceType))
            {
                return this.CreateClientForRemoteCall(serviceType, serviceSettings);
            }

            throw new NotSupportedException(
                $"{name} not supported for Remote or Proxy call, please implement correct interface");

        }
        private HttpClient CreateClientForRemoteCall(Type serviceType, RemoteCallServiceSetting serviceSettings)
        {
            if (!_httpClientsForRemoteCall.TryGetValue(serviceSettings.Endpoint, out var httpClient))
            {
                httpClient = new HttpClientForInbound(
                    this._httpContextAccessor,
                    serviceSettings,
                    this._serializer
                );
                httpClient.BaseAddress = new Uri(serviceSettings.Endpoint);
                _httpClientsForRemoteCall.AddOrUpdate(serviceSettings.Endpoint, httpClient, (s, client) => client);
            }

            return httpClient;
        }
        private Type GetServiceType(string typeFullName)
        {
            var serviceType = AssemblyDiscovery.GetInstance().CommonAssemblies
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(x => x.FullName == typeFullName);
            if (serviceType == null)
            {
                throw new NotSupportedException($"{typeFullName} not founded in abstract assemblies");
            }

            return serviceType;
        }
        private RemoteCallServiceSetting GetServiceSettings(Type serviceType)
        {
            var serviceSettings = this._serviceSettings.Value[serviceType.Name];
            if (serviceSettings == null)
            {
                throw new NotSupportedException($"{serviceType.Name} not founded in appsettings");
            }

            return serviceSettings;
        }
    }
}
