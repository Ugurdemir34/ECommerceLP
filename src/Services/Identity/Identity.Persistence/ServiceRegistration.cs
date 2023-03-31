using Identity.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddIdentityPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<UserContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("UserDB"));
            });

        }
    }
}