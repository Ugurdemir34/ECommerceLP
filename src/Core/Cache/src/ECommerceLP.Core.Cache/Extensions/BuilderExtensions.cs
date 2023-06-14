using ECommerceLP.Core.Abstraction.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ECommerceLP.Core.Cache.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddNexusCache(this IServiceCollection services, IConfiguration config)
        {
            if (services == null)
            {
                throw new ApplicationException($"ServiceCollection: {nameof(services)} not found.");
            }
            services.AddSingleton(typeof(IOptions<MemoryCacheOptions>), x =>
            {
                var configuration = x.GetRequiredService<IConfiguration>();
                var options = new MemoryCacheOptions();
                configuration.Bind(nameof(MemoryCacheOptions), options);
                return options ?? new MemoryCacheOptions();
            });

            services.AddSingleton(typeof(IOptions<RedisCacheOptions>), x =>
            {
                var configuration = x.GetRequiredService<IConfiguration>();
                var options = configuration.GetSection("DistributedCache").Get<RedisCacheOptions>();
                configuration.Bind(nameof(RedisCacheOptions), options);
                return options ?? new RedisCacheOptions();
            });

            services.AddSingleton(x =>
            {
                var options = x.GetRequiredService<IOptions<RedisCacheOptions>>();
                return new RedisCache(options);
            });
            services.AddSingleton<ECommerceMemoryCache>();
            services.AddScoped<ECommerceDistributedCache>();
            services.AddScoped<ECommerceCache>();

            services.AddSingleton(typeof(IMemoryCache), x => x.GetRequiredService<ECommerceMemoryCache>());
            services.AddSingleton(typeof(IECommerceMemoryCache), x => x.GetRequiredService<ECommerceMemoryCache>());

            services.AddScoped(typeof(IDistributedCache), x => x.GetRequiredService<IECommerceDistributedCache>());
            services.AddScoped(typeof(IECommerceDistributedCache), x => x.GetRequiredService<ECommerceDistributedCache>());

            services.AddScoped(typeof(IECommerceCache), x => x.GetRequiredService<ECommerceCache>());
            return services;
        }
    }
}
