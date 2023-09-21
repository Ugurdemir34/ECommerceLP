using ECommerceLP.Core.DDD.Abstraction;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using ECommerceLP.Core.UnitOfWork.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.UnitOfWork.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        #region Variables
        public Dictionary<object, Type> repositories = new Dictionary<object, Type>();
        public TContext Context { get; }
        #endregion
        #region Constructor
        public UnitOfWork(TContext context)
        {
            Context = context;
        }
        #endregion
        #region Get Command Method
        public ICommandRepository<TEntity> GetCommandRepository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as ICommandRepository<TEntity>;
            }
            var repo = new CommandRepository<TEntity>(Context);
            repositories.Add(repo, typeof(TEntity));
            return repo;
        }
        #endregion
        #region Get Query Method
        public IQueryRepository<TEntity> GetQueryRepository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IQueryRepository<TEntity>;
            }
            var repo = new QueryRepository<TEntity>(Context);
            repositories.Add(repo, typeof(TEntity));
            return repo;
        }
        #endregion
        #region Commits
        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
        #endregion
        #region Save Changes
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }


        #endregion
        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
