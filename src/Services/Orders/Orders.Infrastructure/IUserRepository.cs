using ECommerceLP.Application.Repositories;
using Identity.Domain.Aggregate.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure
{
    public interface IUserRepository:ICommandRepository<User>
    {
    }
}
