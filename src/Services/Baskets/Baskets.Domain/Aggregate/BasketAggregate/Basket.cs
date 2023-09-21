using ECommerceLP.Core.DDD.Abstraction;
using ECommerceLP.Core.Mongo.Abstractions.Attributes;
using ECommerceLP.Core.Mongo.Abstractions.Document;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Domain.Aggregate.BasketAggregate
{
    [CollectionInfo(CollectionName ="baskets")]
    public class Basket : DocumentBase, IAggregateRoot
    {
        [BsonElement("userid")]
        public Guid UserId { get; set; }
        [BsonElement("basketItems")]
        public List<BasketItem> BasketItems { get; set; }
        [BsonElement("totalPrice")]
        public float TotalPrice => BasketItems.Sum(b => b.Price);
        [BsonElement("isOrdered")]
        public bool IsOrdered { get; set; }
        public Basket()
        {

        }
        public Basket(Guid userId)
        {
            UserId = userId;
            BasketItems = new List<BasketItem>();
        }
    }
}
