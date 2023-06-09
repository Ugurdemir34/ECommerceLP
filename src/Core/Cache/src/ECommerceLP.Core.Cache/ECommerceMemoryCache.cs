using ECommerceLP.Core.Abstraction.Cache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Cache
{
    public class ECommerceMemoryCache : IECommerceMemoryCache, IMemoryCache
    {
        private readonly IMemoryCache _memoryCache;
        public ECommerceMemoryCache(IOptions<MemoryCacheOptions> options)
        {
            this._memoryCache = new MemoryCache(options);
        }
        public Task<T> GetAsync<T>(string key, CancellationToken token = default)
        {
            return Task.Run(() =>
            {
                var watch = Stopwatch.StartNew();
                var cacheItem = this._memoryCache.Get<ECommerceCacheItem<T>>(key);
                watch.Stop();

                if (cacheItem == null)
                {
                    throw new Exception(key);
                }

                return cacheItem.Value;
            }, token);
        }

        public Task<(bool keyExists, T cacheItem)> TryGetAsync<T>(
            string key,
            CancellationToken token = default)
        {
            return Task.Run(() =>
            {
                var watch = Stopwatch.StartNew();
                var cacheItem = this._memoryCache.Get<ECommerceCacheItem<T>>(key);
                watch.Stop();
                return (cacheItem != null, cacheItem != null ? cacheItem.Value : default(T));
            }, token);
        }

        public Task SetAsync<T>(T cacheItem, string key, CancellationToken token = default)
        {
            var watch = Stopwatch.StartNew();
            var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(3),
                SlidingExpiration = TimeSpan.FromHours(1)
            };


            return Task.Run(() =>
            {
                _ = this._memoryCache.Set(key, new ECommerceCacheItem<T>(cacheItem), memoryCacheEntryOptions);
                watch.Stop();

            }, token);
        }

        public Task<bool> ExistsAsync<T>(string key, CancellationToken token = default)
        {
            return Task.Run(() =>
            {
                var cacheItem = this._memoryCache.Get<ECommerceCacheItem<T>>(key);
                return cacheItem != null;
            }, token);
        }

        public Task RemoveAsync<T>(string key, CancellationToken token = default)
        {
            return Task.Run(() =>
            {
                var watch = Stopwatch.StartNew();
                this._memoryCache.Remove(key);
                watch.Stop();

            }, token);
        }

        #region IMemoryCache implementation

        public void Dispose()
        {
            this._memoryCache.Dispose();
        }

        public bool TryGetValue(object key, out object value)
        {
            return this._memoryCache.TryGetValue(key, out value);
        }

        public ICacheEntry CreateEntry(object key)
        {
            return this._memoryCache.CreateEntry(key);
        }

        public void Remove(object key)
        {
            this._memoryCache.Remove(key);
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

        #endregion  IMemoryCache implementation
    }
}
