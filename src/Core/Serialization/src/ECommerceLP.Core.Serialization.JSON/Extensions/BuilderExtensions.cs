using ECommerceLP.Common.Serialization;
using ECommerceLP.Core.Serialization.Abstraction;
using ECommerceLP.Core.Serialization.JSON;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Serialization.JSON.Extensions
{
    public class JSONSerializationOptions
    {
    }

    public static class BuilderExtensions
    {
        public static IServiceCollection AddJSONSerialization(this IServiceCollection services,
            Action<JSONSerializationOptions> setupAction = null)
        {
            if (services == null)
            {
                throw new ApplicationException($"ServiceCollection: {nameof(services)} not found.");
            }

            JsonConvert.DefaultSettings = () => new SerializerSettings();
            foreach (var serviceType in typeof(JSONSerializer).GetInterfaces())
            {
                services.AddScoped(serviceType, typeof(JSONSerializer));
            }

            if (setupAction != null)
            {
                services.Configure(setupAction);
            }

            return services;
        }
    }
}
