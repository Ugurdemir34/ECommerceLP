using ECommerceLP.Core.DDD.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Aggregate.OrderAggregates
{
    public class OrderItem : BaseEntity, IAggregateRoot
    {
        public OrderItem()
        {
            
        }
        public OrderItem(Guid orderId, Guid productId, int amount, float price)
        {
            OrderId = orderId;
            ProductId = productId;
            Amount = amount;
            Price = price;
        }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Amount { get; private set; }
        public float Price { get; private set; }
        public Order Order { get; private set; }
    }
}
