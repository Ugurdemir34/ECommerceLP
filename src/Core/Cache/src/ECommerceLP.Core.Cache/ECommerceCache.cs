using ECommerceLP.Core.Abstraction.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Cache
{
    public class ECommerceCache : IECommerceCache
    {
        private readonly IECommerceMemoryCache _memoryCache;

        private readonly IECommerceDistributedCache _distributedCache;

        public ECommerceCache(
            IECommerceMemoryCache memoryCache,
            IECommerceDistributedCache distributedCache)
        {
            this._memoryCache = memoryCache;
            this._distributedCache = distributedCache;
        }

        public async Task<T> GetAsync<T>(string key, CancellationToken token = default)
        {
            var (keyExist, cacheItem) = await this._memoryCache.TryGetAsync<T>(key, token);
            if (keyExist)
            {
                return cacheItem;
            }

            cacheItem = await this._distributedCache.GetAsync<T>(key, token);
            await this._memoryCache.SetAsync(cacheItem, key, token: token);

            return cacheItem;
        }

        public async Task<(bool keyExists, T cacheItem)> TryGetAsync<T>(string key, CancellationToken token = default)
        {
            var result = await this._memoryCache.TryGetAsync<T>(key, token);
            if (result.keyExists)
            {
                return result;
            }

            result = await this._distributedCache.TryGetAsync<T>(key, token);
            if (result.keyExists)
            {
                await this._memoryCache.SetAsync(result.cacheItem, key, token: token);
            }

            return result;
        }

        public async Task SetAsync<T>(T cacheItem, string key, CancellationToken token = default)
        {
            await this._memoryCache.SetAsync(cacheItem, key, token);
            await this._distributedCache.SetAsync(cacheItem, key, token);
        }

        public async Task<bool> ExistsAsync<T>(string key, CancellationToken token = default)
        {
            return await this._memoryCache.ExistsAsync<T>(key, token) || await this._distributedCache.ExistsAsync<T>(key, token);
        }

        public async Task RemoveAsync<T>(string key, CancellationToken token = default)
        {
            await this._memoryCache.RemoveAsync<T>(key, token);
            await this._distributedCache.RemoveAsync<T>(key, token);
        }

        public Task<T> GetAsync<T>(CancellationToken token = default)
        {
            throw new ApplicationException();
        }

        public Task<(bool keyExists, T cacheItem)> TryGetAsync<T>(CancellationToken token = default)
        {
            throw new ApplicationException();
        }

        public Task SetAsync<T>(T cacheItem, CancellationToken token = default)
        {
            throw new ApplicationException();
        }

        public Task<bool> ExistsAsync<T>(CancellationToken token = default)
        {
            throw new ApplicationException();
        }

        public Task RemoveAsync<T>(CancellationToken token = default)
        {
            throw new ApplicationException();
        }
    }
}
