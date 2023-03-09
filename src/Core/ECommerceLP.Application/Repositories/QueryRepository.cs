using ECommerceLP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public QueryRepository(DbContext context)
        {
            _context = context;
            //_context.Set<User>().Add(new User
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Uğur",
            //    LastName = "Demir",
            //    PasswordHash = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=",
            //    EMail = "ugurdemir551@gmail.com",
            //    PhoneNumber = "5340682415",
            //    UserName = "Ugur",
            //});
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
