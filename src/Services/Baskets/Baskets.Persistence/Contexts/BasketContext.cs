using Baskets.Domain.Aggregate.BasketAggregate;
using ECommerceLP.Core.Abstraction.Settings;
using ECommerceLP.Core.Mongo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Persistence.Contexts
{
    public class BasketContext : MongoContext
    {
        public BasketContext(IOptions<DatabaseSettings> option) : base(option)
        {
        }
    }
}
