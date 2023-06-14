using ECommerceLP.Core.Abstraction.Cache;
using ECommerceLP.Core.CQRS.Abstraction.Query;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Collections;
using System.Globalization;
using System.Security.Authentication;
using System.Text;

namespace ECommerceLP.Core.CQRS.Decorators
{
    public class CacheQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IRequestHandler<TQuery, TResult> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IECommerceCache _cache;
        private readonly IConfiguration _configuration;
        private bool isCacheable;
        public CacheQueryHandlerDecorator(IRequestHandler<TQuery, TResult> decorated, IUnitOfWork unitOfWork, IConfiguration configuration, IECommerceCache cache)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _cache = cache;
            //isCacheRemoveble = this._decorated.GetType().GetInterfaces().Any(x => x.Name == nameof(ICommandRemoveCache));
        }

        public async Task<TResult> Handle(TQuery command, CancellationToken cancellationToken)
        {
            TResult result;

            try
            {
                if (!this.isCacheable)
                {
                    result = await this._decorated.Handle(command, cancellationToken);
                    return result;
                }
                //var cacheKey = this.Get
            }
            catch (Exception)
            {

                throw;
            }
            //var result = await _decorated.Handle(command, cancellationToken);

            //if (isCacheRemoveble)
            //{
            //    var modelName = command.GetType().FullName;//String extension
            //    //if (!string.IsNullOrWhiteSpace(modelName)) RemoveCache(_configuration.GetRedisKeysByModelName(modelName));
            //}

            //await _unitOfWork.CommitAsync();

            //_unitOfWork.Dispose();

            //return result;
            return default;
        }

        private string GetCacheKey(TQuery request)
        {
            var moduleName = "";//this._nexusInfoAccessor.ModuleInfo.Name?.Replace(" ", string.Empty);
            var cacheKey = CreateCacheKey(request);

            return string.IsNullOrWhiteSpace(cacheKey)
                ? $"{moduleName}:{this._decorated.GetType().Name}"
                : $"{moduleName}:{this._decorated.GetType().Name}:{cacheKey}";
        }
        private static string CreateCacheKey(object obj, string propName = null)
        {
            var sb = new StringBuilder();
            if (obj.GetType().IsValueType || obj is string)
            {
                _ = sb.AppendFormat(CultureInfo.CurrentCulture, "{0}_{1}|", propName, obj);
            }
            else
            {
                var properties = obj.GetType().GetProperties().Where(x => x.Name != "QueryId").ToArray();
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

            return string.IsNullOrEmpty(sb.ToString())
            ? "-"
            : ECommerceLP.Core.Security.SecurityHashing.ComputeHash(HashAlgorithmType.Sha256, sb.ToString());
        }
    }
}
