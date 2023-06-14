using ECommerceLP.Application.Extensions;
using ECommerceLP.Application.Interfaces.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Decorators
{
    public class CacheQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IRequestHandler<TQuery, TResult> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache;
        private readonly IConfiguration _configuration;
        private bool isCacheRemoveble = false;
        public CacheQueryHandlerDecorator(IRequestHandler<TQuery, TResult> decorated, IUnitOfWork unitOfWork, IDistributedCache distributedCache, IConfiguration configuration)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
            _configuration = configuration;
            //isCacheRemoveble = this._decorated.GetType().GetInterfaces().Any(x => x.Name == nameof(ICommandRemoveCache));
        }

        public async Task<TResult> Handle(TQuery command, CancellationToken cancellationToken)
        {
            var result = await _decorated.Handle(command, cancellationToken);

            if (isCacheRemoveble)
            {
                var modelName = command.GetType().FullName;//String extension
                if (!string.IsNullOrWhiteSpace(modelName)) RemoveCache(_configuration.GetRedisKeysByModelName(modelName));
            }

            await _unitOfWork.CommitAsync();

            _unitOfWork.Dispose();

            return result;
        }

        public void RemoveCache(List<RedisKey> keys)
        {
            foreach (var key in keys)
            {
                _distributedCache.Remove(key);
            }
            throw new ApplicationException();
        }
    }
}
