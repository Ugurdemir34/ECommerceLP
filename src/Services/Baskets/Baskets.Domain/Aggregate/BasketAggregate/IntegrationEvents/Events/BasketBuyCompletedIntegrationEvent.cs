using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Domain.Aggregate.BasketAggregate.IntegrationEvents.Events
{
    public class BasketBuyCompletedIntegrationEvent : IntegrationEvent
    {
        public string BasketId { get; set; }
        public bool IsSuccess { get; set; }
        public BasketBuyCompletedIntegrationEvent()
        {
            
        }
    }
}
