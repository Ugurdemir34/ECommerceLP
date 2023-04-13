using Identity.Domain.Aggregate.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt):base(opt)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserType { get; set; }
    }
}
