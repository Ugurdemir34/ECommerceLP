using ECommerceLP.Core.DDD.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Domain.Aggregate.BasketAggregate
{
    public class Basket : BaseEntity, IAggregateRoot
    {
        public Guid UserId { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        public float GetTotalPrice => BasketItems.Sum(b => b.Price);
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
