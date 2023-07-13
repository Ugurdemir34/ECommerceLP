using EventBus.Base.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationService.IntegrationEvents.Events;

namespace NotificationService.IntegrationEvents.EventHandlers
{
    public class OrderConfirmIntegrationEventHandler : IIntegrationEventHandler<OrderConfirmIntegrationEvent>
    {
        public OrderConfirmIntegrationEventHandler()
        {
        }
        public Task Handle(OrderConfirmIntegrationEvent @event)
        {
            Console.WriteLine($"{@event.Message}");
            //_mailService.SendMailAsync(message);
            return Task.CompletedTask;
        }
    }
}
