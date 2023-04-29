using EventBus.Base.Abstraction;
using EventBus.Base.Events;
using Orders.Common.Interfaces;
using Orders.Domain.Aggregate.OrderAggregates.DomainEvents.Events;
using Orders.Domain.Aggregate.OrderAggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.IntegrationEventHandlers
{
    public class OrderConfirmIntegrationEventHandler : IIntegrationEventHandler<OrderConfirmIntegrationEvent>
    {
        private readonly IEventBus _eventBus;

        public OrderConfirmIntegrationEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(OrderConfirmIntegrationEvent @event)
        {
            _eventBus.Publish(@event);
            return Task.CompletedTask;
        }
    }
}
