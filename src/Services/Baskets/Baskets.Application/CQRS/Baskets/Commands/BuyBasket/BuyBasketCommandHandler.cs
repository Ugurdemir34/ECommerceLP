using Baskets.Application.CQRS.Baskets.Extensions;
using Baskets.Common.Constants;
using Baskets.Common.Dtos;
using Baskets.Domain.Aggregate.BasketAggregate;
using Baskets.Domain.Aggregate.BasketAggregate.IntegrationEvents.Events;
using Baskets.Persistence.Contexts;
using ECommerceLP.Core.Abstraction.Exception;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.Mongo.Abstractions;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using EventBus.Base.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.CQRS.Baskets.Commands.BuyBasket
{
    public class BuyBasketCommandHandler : ICommandHandler<BuyBasketCommand, BasketDto>
    {
        private readonly ILogger<BuyBasketCommandHandler> _logger;
        private readonly IMongoRepositoryFactory<BasketContext> _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEventBus _eventBus;

        public BuyBasketCommandHandler(ILogger<BuyBasketCommandHandler> logger, IMongoRepositoryFactory<BasketContext> context, IHttpContextAccessor httpContextAccessor, IEventBus eventBus)
        {
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _eventBus = eventBus;
        }

        public async Task<BasketDto> Handle(BuyBasketCommand request, CancellationToken cancellationToken)
        {
            var basketRepo = _context.GetRepository<Basket>();
            request.UserId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst("userId").Value);
            var basket = await basketRepo.FindAsync(b => b.UserId == request.UserId && b.Id == request.BasketId);
            if (basket == null)
            {
                //_logger.LogInformation(Messages.BasketNotFound, true, request);
                throw new CustomBusinessException(Messages.BasketNotFound);
            }
            //await basketRepo.UpdateAsync(a=>a.Set(b=>b.IsOrdered,true),b=>b.Id==request.BasketId);
            var @event = new BasketBuyStartedIntegrationEvent()
            {
                CardHolderName = request.CardHolderName,
                CardNumber = request.CardNumber,
                CardSecurityNumber = request.CardSecurityNumber,
                FullAddress = request.FullAddress,
                BasketId = request.BasketId
            };
            _eventBus.Publish(@event);
            return basket.Map();
        }
    }
}
