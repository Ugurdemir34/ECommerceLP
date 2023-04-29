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
        public OrderConfirmIntegrationEvent(DateTime orderDate,
                                                float totalPrice,
                                                string fullAddress,
                                                Guid userId)
        {
            UserId = userId;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            FullAddress = fullAddress;
        }
    }
}
