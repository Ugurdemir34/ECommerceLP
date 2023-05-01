using ECommerceLP.Application.Extensions;
using ECommerceLP.Application.Interfaces.Abstract;
using ECommerceLP.Application.Services;
using ECommerceLP.Application.Settings;
using ECommerceLP.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Decorators
{
    public sealed class QueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IRequestHandler<TQuery, TResult> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _distributedCache;
        private readonly IConfiguration _configuration;
        private bool isCacheable = false;
        public QueryHandlerDecorator(IRequestHandler<TQuery, TResult> decorated, IUnitOfWork unitOfWork, ICacheService distributedCache, IConfiguration configuration)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
            _configuration = configuration;
            isCacheable = this._decorated.GetType().GetInterfaces().Any(x => x.Name == nameof(IQueryCacheable));
        }

        public async Task<TResult> Handle(TQuery query, CancellationToken cancellationToken)
        {
            if (this.isCacheable)
            {
                var cacheKey = this.GetCacheKey(query);
                var value = _distributedCache.GetValue(cacheKey);
                if (value == null)
                {
                    var result = await _decorated.Handle(query, cancellationToken);
                    var cacheData = JsonConvert.SerializeObject(result);
                    //byte[] objectToCache = JsonSerializer.SerializeToUtf8Bytes(result);
                    _distributedCache.SetValue(cacheKey, cacheData);
                    value = _distributedCache.GetValue(cacheKey);
                }

                //var jsonToDeserialize = Encoding.UTF8.GetString(value);
                var cachedResult = JsonConvert.DeserializeObject<TResult>(value);
                return cachedResult;
            }
            else
            {
                return await _decorated.Handle(query, cancellationToken);
            }
        }

        private string GetCacheKey(TQuery request)
        {
            var modelName = request.GetType().FullName?.GetModelName();

            var cacheKey = CreateCacheKey(modelName);

            var cacheKeyWithQueryName = string.IsNullOrWhiteSpace(cacheKey)
                ? $"{this._decorated.GetType().Name}"
                : $"{this._decorated.GetType().Name}:{cacheKey}";

            return string.IsNullOrWhiteSpace(modelName)
                ? $"{cacheKeyWithQueryName}"
                : $"{modelName}:{cacheKeyWithQueryName}";
        }

        public static string CreateCacheKey(object obj, string propName = null)
        {
            var sb = new StringBuilder();
            if (obj.GetType().IsValueType || obj is string)
            {
                _ = sb.AppendFormat(CultureInfo.CurrentCulture, "{0}_{1}|", propName, obj);
            }
            else
            {
                var properties = obj.GetType().GetProperties().Where(x => x.Name != "RequestId").ToArray();
                if (!properties.Any())
                {
                    return default;
                }
                foreach (var prop in properties)
                {
                    if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                    {
                        var get = prop.GetGetMethod();
                        if (!get.IsStatic && get.GetParameters().Length == 0)
                        {
                            var collection = (IEnumerable)get.Invoke(obj, null);
                            if (collection != null)
                            {
                                foreach (var o in collection)
                                {
                                    _ = sb.Append(CreateCacheKey(o, prop.Name));
                                }
                            }
                        }
                    }
                    else
                    {
                        _ = sb.AppendFormat(CultureInfo.CurrentCulture, "{0}{1}_{2}|", propName, prop.Name, prop.GetValue(obj, null));
                    }
                }
            }
            return sb.ToString();
        }
    }
}
