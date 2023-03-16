using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddIdentityInfrastructre(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<UserContext>(opt =>
            {              
                //opt.UseSqlServer(@"Server=DESKTOP-5D8FOCF\UGUR;Database=ECommerceDB;Trusted_Connection=True;Encrypt=False");
                opt.UseSqlServer(configuration.GetConnectionString("UserDB"));
               // opt.UseInMemoryDatabase("UserDB");
            });

        }
    }
}