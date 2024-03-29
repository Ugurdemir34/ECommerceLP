﻿using Baskets.Domain.Aggregate.BasketAggregate;
using Baskets.Domain.Repositories;
using Baskets.Persistence.Contexts;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Persistence.Repositories
{
    public class BasketRepository:ICustomRepository,IBasketRepository
    {
        private readonly BasketContext _context;
        public BasketRepository(BasketContext context)
        {
            _context = context;
        }

        public Task AddAsync(Basket basket, CancellationToken token)
        {
            //var added = _context.AddAsync(basket, token);
            return Task.CompletedTask;
        }

        public async Task<Basket> GetAsync(Expression<Func<Basket, bool>> predicate,CancellationToken token)
        {
            return default;
            //var entity = _context.Set<Basket>();
            //return await entity.FirstOrDefaultAsync(predicate,token);
        }
    }
}
