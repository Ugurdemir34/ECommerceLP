using ECommerceLP.Application.Extensions;
using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public sealed class CommandHandlerDecorator<TCommand,TResult>:ICommandHandler<TCommand,TResult> where TCommand:ICommand<TResult>
    {
        private readonly IRequestHandler<TCommand, TResult> _decorated;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache;
        private readonly IConfiguration _configuration;
        private bool isCacheRemoveble = false;
        public CommandHandlerDecorator(IRequestHandler<TCommand, TResult> decorated, IUnitOfWork unitOfWork, IDistributedCache distributedCache, IConfiguration configuration)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
            _configuration = configuration;
            //isCacheRemoveble = this._decorated.GetType().GetInterfaces().Any(x => x.Name == nameof(ICommandRemoveCache));
        }

        public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
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
        }
    }
}
