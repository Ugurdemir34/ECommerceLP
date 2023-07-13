using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Domain.Aggregate.BasketAggregate.IntegrationEvents.Events
{
    public class BasketBuyStartedIntegrationEvent : IntegrationEvent
    {
        public string BasketId { get; set; }
        public string FullAddress { get; set; }
        public string CardNumber { get; set; }
        public string CardSecurityNumber { get; set; }
        public string CardHolderName { get; set; }
        public BasketBuyStartedIntegrationEvent()
        {

        }
        public BasketBuyStartedIntegrationEvent(string fullAddress, string cardNumber, string cardSecurityNumber, string cardHolderName)
        {
            FullAddress = fullAddress;
            CardNumber = cardNumber;
            CardSecurityNumber = cardSecurityNumber;
            CardHolderName = cardHolderName;
        }
    }
}
