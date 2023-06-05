using EventBus.Base.Events;
using Orders.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Aggregate.OrderAggregates.IntegrationEvents.Events
{
    public class OrderShippedIntegrationEvent : IntegrationEvent
    {
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public string FullAddress { get; set; }
        public Guid UserId { get; set; }

        public string Message { get; set; }

        public OrderShippedIntegrationEvent(DateTime orderDate, float totalPrice, string fullAddress, Guid userId, string message)
        {
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            FullAddress = fullAddress;
            UserId = userId;
            Message = message;
        }
        public OrderShippedIntegrationEvent()
        {

        }
    }
}
