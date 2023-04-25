using Orders.Common.Interfaces;
using Orders.Domain.Aggregate.OrderAggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Aggregate.OrderAggregates.DomainEvents
{
    public class OrderInformationEvent:IDomainEvent
    {
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public Address Address { get; set; }
        public Guid UserId { get; set; }
        public OrderInformationEvent()
        {
            
        }
    }
}
