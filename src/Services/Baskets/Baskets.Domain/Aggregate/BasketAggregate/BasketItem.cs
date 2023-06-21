using ECommerceLP.Core.DDD.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Domain.Aggregate.BasketAggregate
{
    public class BasketItem:BaseEntity,IAggregateRoot
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public Basket Basket { get; set; }
        public BasketItem()
        {

        }
        public BasketItem(Guid productId, string productName, float price, int amount)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Amount = amount;
        }
    }
}
