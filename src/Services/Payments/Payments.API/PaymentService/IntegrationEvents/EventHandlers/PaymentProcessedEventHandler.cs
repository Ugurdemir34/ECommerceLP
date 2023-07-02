using EventBus.Base.Abstraction;
using PaymentService.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.IntegrationEvents.EventHandlers
{
    public class PaymentProcessedEventHandler : IIntegrationEventHandler<PaymentProcessedIntegrationEvent>
    {
        private readonly IEventBus _eventBus;
        public PaymentProcessedEventHandler(IEventBus eventBus = null)
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
