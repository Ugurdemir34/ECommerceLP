using Baskets.Domain.Aggregate.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Domain.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetAsync(Expression<Func<Basket,bool>> predicate,CancellationToken token);
        Task AddAsync(Basket basket,CancellationToken token);
    }
}
