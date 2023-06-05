using ECommerceLP.Application.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ECommerceLP.Infrastructure.Cache
{
    public class RedisService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public string GetValue(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return db.StringGet(key);
        }

        public void SetValue(string key, string value)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var redisValue = new RedisValue(value);
            //db.HashSetAsync(key, new RedisValue(value.GetType().GetProperty("Id").GetValue(value).ToString()), value.ToString());
            db.StringSet(key, redisValue);
        }

        public void RemoveValue(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            db.KeyDelete(key);
        }

        public void SetList<T>(string key, IEnumerable<T> values)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var serializedValues = values.Select(x => JsonConvert.SerializeObject(x)).ToArray();
            db.ListRightPush(key, serializedValues.Select(v => (RedisValue)v).ToArray());

        }

        public List<T> GetList<T>(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var serializedValues = db.ListRange(key);

            var values = new List<T>();
            foreach (var serializedValue in serializedValues)
            {
                var value = JsonConvert.DeserializeObject<T>(serializedValue);
                values.Add(value);
            }

            return values;
        }

        public void RemoveList(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            db.KeyDelete(key);
        }
    }
}
