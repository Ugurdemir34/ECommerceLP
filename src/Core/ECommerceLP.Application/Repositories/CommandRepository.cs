using ECommerceLP.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Repositories
{
    public class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly DbContext _context;
        public CommandRepository(DbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            //if (entity is BaseDefinitionEntity newEntity)
            //{
            //    var creatorId = Guid.Parse(_contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //    newEntity.CreatedBy = creatorId;
            //    newEntity.ModifiedBy = creatorId;
            //    await _context.AddAsync(newEntity);
            //}
            var addedEntity = await _context.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = _context.Set<T>();
            var deleted = await entity.FindAsync(id);
            deleted.Delete();
            _context.Update(deleted);
        }

        public async Task HardDeleteAsync(Guid id)
        {
            var entity = _context.Set<T>();
            var deleted = await entity.FindAsync(id);
            _context.Remove(deleted);
        }
        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
