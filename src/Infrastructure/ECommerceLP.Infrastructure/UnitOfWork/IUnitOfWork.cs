using ECommerceLP.Application.Repositories;
using ECommerceLP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Products.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommandRepository<TEntity> GetCommandRepository<TEntity>() where TEntity : BaseEntity;
        IQueryRepository<TEntity> GetQueryRepository<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
        //void CreateTransaction();
        //void RollBack();
        //void Save();
        //void Commit();
        //public IProductRepository ProductRepository { get; }

    }
}
