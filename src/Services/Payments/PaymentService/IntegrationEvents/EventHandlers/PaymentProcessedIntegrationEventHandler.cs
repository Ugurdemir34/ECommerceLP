using Baskets.Persistence.Contexts;
using ECommerceLP.Core.Mongo.Abstractions;
using EventBus.Base.Abstraction;
using PaymentService.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.IntegrationEvents.EventHandlers
{
    public class PaymentProcessedIntegrationEventHandler : IIntegrationEventHandler<PaymentProcessedIntegrationEvent>
    {
        private readonly IEventBus _eventBus;
        public PaymentProcessedIntegrationEventHandler(IEventBus eventBus = null)
        {
            _eventBus = eventBus;
        }
        public Task Handle(PaymentProcessedIntegrationEvent @event)
        {
            Console.WriteLine($"{@event.Message}");
            var nextEvent = new PaymentCompletedIntegrationEvent
            {
                TotalPrice = @event.TotalPrice,
                Message = $"Payment succeed !"
            };
            _eventBus.Publish(nextEvent);
            return Task.CompletedTask;
        }
    }
}
