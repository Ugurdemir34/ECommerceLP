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
        public Basket Basket { get; set; }
        public string FullAddress { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; }
        public string CardSecurityNumber { get; }
        public string CardHolderName { get; }
        public BasketBuyStartedIntegrationEvent(Basket basket, string fullAddress, int cardTypeId, string cardNumber, string cardSecurityNumber, string cardHolderName)
        {
            Basket = basket;
            FullAddress = fullAddress;
            CardTypeId = cardTypeId;
            CardNumber = cardNumber;
            CardSecurityNumber = cardSecurityNumber;
            CardHolderName = cardHolderName;
        }
    }
}
