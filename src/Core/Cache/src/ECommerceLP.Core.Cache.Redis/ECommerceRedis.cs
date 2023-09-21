using ECommerceLP.Core.Abstraction.Cache;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace ECommerceLP.Core.Cache.Redis
{
    public class ECommerceRedis : IECommerceCache
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public ECommerceRedis(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<T> GetValue<T>(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var data = await db.StringGetAsync(key);
            return string.IsNullOrEmpty(data)?default(T): JObject.Parse(data).ToObject<ECommerceCacheItem<T>>().Value;
        }
        public async Task SetValue<T>(string key, T value)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var redisValueObject = JObject.FromObject(new ECommerceCacheItem<T>(value)).ToString();
            var redisValue = new RedisValue(redisValueObject);
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