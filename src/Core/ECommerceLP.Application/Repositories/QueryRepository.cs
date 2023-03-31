using ECommerceLP.Common.Collections.Abstract;
using ECommerceLP.Common.Collections.Extensions;
using ECommerceLP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public QueryRepository(DbContext context)
        {
            _context = context;
            //_context.Set<User>().Add(new User
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Uğur",
            //    LastName = "Demir",
            //    PasswordHash = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=",
            //    EMail = "ugurdemir551@gmail.com",
            //    PhoneNumber = "5340682415",
            //    UserName = "Ugur",
            //});
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
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
