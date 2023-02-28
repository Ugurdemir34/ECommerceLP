using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt):base(opt)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Uğur",
                LastName = "Demir",
                PasswordHash = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=",
                EMail = "ugurdemir551@gmail.com",
                PhoneNumber = "5340682415",
                UserName = "Ugur",
            });
        }
    }
}
