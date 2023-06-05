using Baskets.Domain.Aggregate.BasketAggregate;
using Baskets.Domain.Repositories;
using Baskets.Persistence.Contexts;
using ECommerceLP.Application.Repositories;
using ECommerceLP.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Persistence.Repositories
{
    public class BasketRepository:CustomRepository,IBasketRepository
    {
        private readonly BasketContext _context;
        public BasketRepository(BasketContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Basket basket, CancellationToken token)
        {
            var added = _context.AddAsync(basket, token);
        }

        public async Task<Basket> GetAsync(Expression<Func<Basket, bool>> predicate,CancellationToken token)
        {
            var entity = _context.Set<Basket>();
            return await entity.FirstOrDefaultAsync(predicate,token);
        }
    }
}
