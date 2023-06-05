using EventBus.Base.Abstraction;
using NotificationService.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.IntegrationEvents.EventHandlers
{
    public class OrderShippedIntegrationEventHandler : IIntegrationEventHandler<OrderShippedIntegrationEvent>
    {

        public OrderShippedIntegrationEventHandler()
        {
        }

        public Task Handle(OrderShippedIntegrationEvent @event)
        {
            Console.WriteLine($"{@event.Message}");
            //_mailService.SendMailAsync(message);
            return Task.CompletedTask;
        }
    }
}
