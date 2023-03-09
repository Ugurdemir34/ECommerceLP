using ECommerceLP.Application.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Extensions
{
    public static class RedisExtensions
    {
        public static void AddRedis(this IServiceCollection serviceCollection,IConfiguration configuration)
        {
            var redisConfig = configuration.GetSection(nameof(RedisConfiguration)) as RedisConfiguration;
            serviceCollection.AddStackExchangeRedisCache(opt=> opt.Configuration = redisConfig.Url);
        }
        public static List<RedisKey> GetRedisKeysByModelName(this IConfiguration configuration,string value)
        {
            var redisConfig = configuration.GetSection(nameof(RedisConfiguration)) as RedisConfiguration;
            using (ConnectionMultiplexer redis= ConnectionMultiplexer.Connect($"{redisConfig.Url},allowAdmin=true"))
            {
                IDatabase db = redis.GetDatabase();
                EndPoint endPoint = redis.GetEndPoints().First();
                var pattern = $"{value}:*";
                var keys = redis.GetServer(endPoint).Keys(pattern:pattern).ToList();
                return keys;
            }
        }
    }
}
