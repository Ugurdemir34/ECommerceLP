using ECommerceLP.Application.Repositories;
using ECommerceLP.Domain.Entities;
using ECommerceLP.Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Products.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Infrastructure.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext:DbContext
    {
        #region Variables
        public Dictionary<object, Type> repositories = new Dictionary<object, Type>();
        private readonly DbContext _context;
        #endregion
        #region Constructor
        public UnitOfWork(TContext context)
        {
            _context = context;
        }
        #endregion
        #region Get Command Method
        public ICommandRepository<TEntity> GetCommandRepository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as ICommandRepository<TEntity>;
            }
            var repo = new CommandRepository<TEntity>(_context);
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
            var repo = new QueryRepository<TEntity>(_context);
            repositories.Add(repo, typeof(TEntity));
            return repo;
        }
        #endregion
        #region Commits
        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        #endregion
        #region Save Changes
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }


        #endregion
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
