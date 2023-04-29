using EventBus.Base.Events;
using Orders.Common.Dtos;
using Orders.Common.Interfaces;
using Orders.Domain.Aggregate.OrderAggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Aggregate.OrderAggregates.DomainEvents.Events
{
    public class OrderConfirmIntegrationEvent : IntegrationEvent
    {
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public AddressDto Address { get; set; }
        public Guid UserId { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
        public OrderConfirmIntegrationEvent(OrderDto order)
        {
            OrderDate = order.OrderDate;
            TotalPrice = order.TotalPrice;
            Address = order.Address;
            UserId = order.UserId;
            OrderItems = order.OrderItems;
        }
    }
}
