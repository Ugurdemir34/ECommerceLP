using Identity.Domain.Aggregate.UserAggregate.Entities;
using Identity.Infrastructure;
using System.Linq.Expressions;

namespace Users.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(List<User> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}