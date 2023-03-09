using Products.Domain;
using System.Linq.Expressions;

namespace Products.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        public Task AddAsync(Product entity)
        {        
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}