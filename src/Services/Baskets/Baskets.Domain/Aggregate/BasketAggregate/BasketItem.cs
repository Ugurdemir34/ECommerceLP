using ECommerceLP.Core.DDD.Abstraction;
using ECommerceLP.Core.Mongo.Abstractions.Document;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Domain.Aggregate.BasketAggregate
{
    public class BasketItem : DocumentBase, IAggregateRoot
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public string BasketId { get; set; }
        //[BsonIgnore]
        //public Basket Basket { get; set; }
        public BasketItem()
        {

        }
        public BasketItem(string basketId, Guid productId, int amount, float price)
        {
            BasketId = basketId;
            ProductId = productId;
            Price = price;
            Amount = amount;
        }
        //[BsonIgnore]
        //public string ParentBasketId
        //{
        //    get { return Basket?.Id ?? default(string)}
        //    set { BasketId = value; }
        //}
        //public void SetParentBasket(Basket basket)
        //{
        //    Basket = basket;
        //}
    }
}
