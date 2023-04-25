using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddProductPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ProductContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("ProductDB"));
            });

        }
    }
}
