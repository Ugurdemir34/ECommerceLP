using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.IntegrationEvents.Events
{
    public class OrderConfirmIntegrationEvent : IntegrationEvent
    {
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public string FullAddress { get; set; }
        public Guid UserId { get; set; }

        public string Message { get; set; }
        public OrderConfirmIntegrationEvent(DateTime orderDate,
                                                float totalPrice,
                                                string fullAddress,
                                                Guid userId,
                                                string message)
        {
            UserId = userId;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            FullAddress = fullAddress;
            Message = message;
        }
    }
}
