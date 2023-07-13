using Baskets.Domain.Aggregate.BasketAggregate;
using Baskets.Domain.Aggregate.BasketAggregate.IntegrationEvents.Events;
using Baskets.Persistence.Contexts;
using ECommerceLP.Core.Mongo.Abstractions;
using EventBus.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Persistence.EventHandlers
{
    public class BasketBuyCompletedIntegrationEventHandler : IIntegrationEventHandler<BasketBuyCompletedIntegrationEvent>
    {
        private readonly IMongoRepositoryFactory<BasketContext> _context;

        public BasketBuyCompletedIntegrationEventHandler(IMongoRepositoryFactory<BasketContext> context)
        {
            _context = context;
        }
        public async Task Handle(BasketBuyCompletedIntegrationEvent @event)
        {
            var basketRepo = _context.GetRepository<Basket>();
            await basketRepo.UpdateAsync(a => a.Set(b => b.IsOrdered, true), b => b.Id == @event.BasketId);
            Console.WriteLine("Sepet silindi ! ");
        }
    }
}
