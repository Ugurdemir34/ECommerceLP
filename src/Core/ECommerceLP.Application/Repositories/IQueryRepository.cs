using ECommerceLP.Common.Collections.Abstract;
using ECommerceLP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Repositories
{
    public interface IQueryRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate);
        Task<List<T>> ListAsync();
        Task<IPagedList<T>> QueryPagedListAsync(Expression<Func<T,bool>> predicate,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null,
            Func<IQueryable<T>,IIncludableQueryable<T,object>> include=null,
            int index=1,
            int size=20,
            CancellationToken cancellationToken=default);
    }
}
