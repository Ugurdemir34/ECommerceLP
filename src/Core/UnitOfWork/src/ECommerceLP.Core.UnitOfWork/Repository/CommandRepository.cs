using ECommerceLP.Core.DDD.Abstraction;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceLP.Core.UnitOfWork.Repository
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

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
            return entity;
        }

        public async Task HardDeleteAsync(Guid id)
        {
            var entity = _context.Set<T>();
            var deleted = await entity.FindAsync(id);
            _context.Remove(deleted);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
            return entity;
        }
    }
}
