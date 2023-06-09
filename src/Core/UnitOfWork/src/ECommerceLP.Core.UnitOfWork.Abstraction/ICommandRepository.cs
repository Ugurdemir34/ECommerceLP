using ECommerceLP.Core.DDD.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.UnitOfWork.Abstraction
{
    public interface ICommandRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id);
        Task HardDeleteAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
    }
}
