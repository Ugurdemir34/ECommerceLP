using ECommerceLP.Domain.Entities;
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
    }
}
