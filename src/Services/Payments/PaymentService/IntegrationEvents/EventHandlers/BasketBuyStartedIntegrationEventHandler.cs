using ECommerceLP.Core.Mongo.Abstractions;
using EventBus.Base.Abstraction;
using Payment.Domain.Aggregate.PaymentAggregates.IntegrationEvents.Events;
using PaymentService.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.IntegrationEvents.EventHandlers
{
    public class BasketBuyStartedIntegrationEventHandler : IIntegrationEventHandler<BasketBuyStartedIntegrationEvent>
    {
        private readonly IEventBus _eventBus;
        public BasketBuyStartedIntegrationEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public Task Handle(Payment.Domain.Aggregate.PaymentAggregates.IntegrationEvents.Events.BasketBuyStartedIntegrationEvent @event)
        {
            Console.WriteLine($"Sepet Onaylandı !");
            var nextEvent = new BasketBuyCompletedIntegrationEvent
            {
                BasketId = @event.BasketId,
                IsSuccess = true
            };
            _eventBus.Publish(nextEvent);
            return Task.CompletedTask;
        }
    }
}
