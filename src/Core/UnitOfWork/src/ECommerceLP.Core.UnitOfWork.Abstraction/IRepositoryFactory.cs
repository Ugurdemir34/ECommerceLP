using ECommerceLP.Core.DDD.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.UnitOfWork.Abstraction
{
    public interface IRepositoryFactory
    {

    }
    public interface IRepositoryFactory<TContext>:IRepositoryFactory where TContext:DbContext
    {
        ICommandRepository<TEntity> GetCommandRepository<TEntity>() where TEntity : BaseEntity;
        IQueryRepository<TEntity> GetQueryRepository<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
        void Commit();
    }
}
