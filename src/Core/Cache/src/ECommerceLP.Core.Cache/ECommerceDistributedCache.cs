using ECommerceLP.Core.Abstraction.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Cache
{
    public class ECommerceDistributedCache : IECommerceDistributedCache
    {

        private readonly IDistributedCache _distributedCache;

        public ECommerceDistributedCache(RedisCache redisCache)
        {
            this._distributedCache = redisCache;
        }

        public  async Task<T> GetAsync<T>(
            string key,
            CancellationToken token = default)
        {
            try
            {
                var watch = Stopwatch.StartNew();

                var data = await this._distributedCache.GetStringAsync(key, token);
                watch.Stop();

                if (string.IsNullOrEmpty(data))
                {
                    throw new Exception(key);
                }

                return JObject.Parse(data).ToObject<ECommerceCacheItem<T>>().Value;
            }
            catch (Exception ex)
            {

                throw new Exception(key);
            }
        }

        public  async Task<(bool keyExists, T cacheItem)> TryGetAsync<T>(
            string key,
            CancellationToken token = default)
        {
            try
            {
                var watch = Stopwatch.StartNew();

                var data = await this._distributedCache.GetStringAsync(key, token);
                watch.Stop();

                return string.IsNullOrEmpty(data)
                    ? (false, default(T))
                    : (true, JObject.Parse(data).ToObject<ECommerceCacheItem<T>>().Value);
            }
            catch (Exception ex)
            {

                throw new Exception(key);
            }
        }

        public  Task SetAsync<T>(T cacheItem,
            string key,         
            CancellationToken token = default)
        {
            var distributedCacheEntryOptions = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddDays(1),
                SlidingExpiration = TimeSpan.FromHours(1)
            };

           
            var watch = Stopwatch.StartNew();

            var data = JObject.FromObject(new ECommerceCacheItem<T>(cacheItem)).ToString();
            watch.Stop();


            return this._distributedCache.SetStringAsync(key, data, distributedCacheEntryOptions, token);
        }

        public  async Task<bool> ExistsAsync<T>(string key, CancellationToken token = default)
        {
            var data = await this._distributedCache.GetStringAsync(key, token);
            return !string.IsNullOrEmpty(data);
        }

        public  Task RemoveAsync<T>(string key, CancellationToken token = default)
        {
            var watch = Stopwatch.StartNew();
            _ = this._distributedCache.RemoveAsync(key, token);
            watch.Stop();
            return Task.CompletedTask;
        }

        #region IDistributedCache implementation

        public byte[] Get(string key)
        {
            return this._distributedCache.Get(key);
        }

        public Task<byte[]> GetAsync(string key, CancellationToken token = default)
        {
            return this._distributedCache.GetAsync(key, token);
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            this._distributedCache.Set(key, value, options);
        }

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            return this._distributedCache.SetAsync(key, value, options, token);
        }

        public void Refresh(string key)
        {
            this._distributedCache.Refresh(key);
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            return this._distributedCache.RefreshAsync(key, token);
        }

        public void Remove(string key)
        {
            this._distributedCache.Remove(key);
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            return this._distributedCache.RemoveAsync(key, token);
        }

        public Task<T> GetAsync<T>(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<(bool keyExists, T cacheItem)> TryGetAsync<T>(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(T cacheItem, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync<T>(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync<T>(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        #endregion IDistributedCache implementation
    }
}
