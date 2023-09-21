using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Aggregate.OrderAggregates.IntegrationEvents.Events
{
    public class PaymentProcessedIntegrationEvent : IntegrationEvent
    {
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public string Message { get; set; }
        public PaymentProcessedIntegrationEvent(DateTime orderDate, float totalPrice, string message)
        {
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            Message = message;
        }
    }
}
