using ECommerceLP.Application.Repositories;
using Products.Domain.Aggregate.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure
{
    public interface IProductRepository:ICommandRepository<Product>
    {
    }
}
