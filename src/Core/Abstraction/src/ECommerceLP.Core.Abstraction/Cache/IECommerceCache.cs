using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Cache
{
    public interface IECommerceCache
    {
        Task<T> GetAsync<T>(CancellationToken token = default);

        Task<T> GetAsync<T>(string key, CancellationToken token = default);

        Task<(bool keyExists, T cacheItem)> TryGetAsync<T>(CancellationToken token = default);

        Task<(bool keyExists, T cacheItem)> TryGetAsync<T>(string key, CancellationToken token = default);

        Task SetAsync<T>(T cacheItem, CancellationToken token = default);

        Task SetAsync<T>(T cacheItem, string key, CancellationToken token = default);

        Task<bool> ExistsAsync<T>(CancellationToken token = default);

        Task<bool> ExistsAsync<T>(string key, CancellationToken token = default);

        Task RemoveAsync<T>(CancellationToken token = default);

        Task RemoveAsync<T>(string key, CancellationToken token = default);
    }
}
