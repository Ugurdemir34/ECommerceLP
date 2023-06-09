using ECommerceLP.Core.Abstraction.Collections;
using ECommerceLP.Core.DDD.Abstraction;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ECommerceLP.Core.UnitOfWork.Repository
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public QueryRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IPagedList<T>> QueryPagedListAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int index = 1,
            int size = 20,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>();
            query = query.AsNoTracking();

            if (include != null) { query = include(query); }
            if (predicate != null) { query.Where(predicate); }
            if (orderBy != null) { orderBy(query); }
            return await query.ToPagedListAsync(index, size, cancellationToken: cancellationToken);

        }
    }
}
