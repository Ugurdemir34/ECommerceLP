using ECommerceLP.Core.DDD.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Domain.Aggregate.CategoryAggregate
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
