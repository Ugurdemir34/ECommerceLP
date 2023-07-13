using Baskets.Persistence.Contexts;
using Baskets.Persistence.EventHandlers;
using EventBus.Base.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddBasketPersistence(this IServiceCollection serviceCollection,IConfiguration configuration)
        {
            serviceCollection.AddTransient<BasketBuyCompletedIntegrationEventHandler>();           
        }
    }
}
