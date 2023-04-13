using ECommerceLP.Common.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Json.Extensions
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
                throw new Exception($"ServiceCollection: {nameof(services)} not found.");
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
