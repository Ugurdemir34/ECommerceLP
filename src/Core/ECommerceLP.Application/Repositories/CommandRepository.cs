using ECommerceLP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public CommandRepository(DbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            var addedEntity = await _context.AddAsync(entity);
        }
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
