using ECommerceLP.Core.Abstraction.Cache;
using ECommerceLP.Core.Abstraction.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Cache.Redis.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddRedis(this IServiceCollection serviceCollection, IConfiguration configuration)
        {          
            var redisConfig = configuration.GetSection("RedisConfiguration").Get<RedisConfiguration>();
            serviceCollection.AddStackExchangeRedisCache(opt => opt.Configuration = redisConfig.Url);
            var aaa = configuration.GetValue<string>("RedisConfiguration:Host");
            var url = configuration.GetValue<string>("RedisConfiguration:Url");
            serviceCollection.AddTransient<IECommerceCache, ECommerceRedis>();
            //serviceCollection.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(new ConfigurationOptions
            //{
            //    EndPoints = { $"{configuration.GetValue<string>("RedisConfiguration:Host")}:{configuration.GetValue<string>("RedisConfiguration:Port")}" },
            //    Ssl = true,
            //    AbortOnConnectFail = false,
            //}));
            serviceCollection.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("127.0.0.1:6379"));

        }
        public static List<RedisKey> GetRedisKeysByModelName(this IConfiguration configuration, string value)
        {
            var redisConfig = configuration.GetSection(nameof(RedisConfiguration)) as RedisConfiguration;
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect($"{redisConfig.Url},allowAdmin=true"))
            {
                IDatabase db = redis.GetDatabase();
                EndPoint endPoint = redis.GetEndPoints().First();
                var pattern = $"{value}:*";
                var keys = redis.GetServer(endPoint).Keys(pattern: pattern).ToList();
                return keys;
            }
        }
    }
}
