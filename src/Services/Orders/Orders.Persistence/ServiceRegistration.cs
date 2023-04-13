using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddOrderPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<OrderContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("OrderDB"));
            });

        }
    }
}
