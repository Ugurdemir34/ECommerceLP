using ECommerceLP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Repositories
{
    public interface ICommandRepository<T> where T : BaseEntity
    {
        Task DeleteAsync(Guid id);
        Task HardDeleteAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
    }
}
