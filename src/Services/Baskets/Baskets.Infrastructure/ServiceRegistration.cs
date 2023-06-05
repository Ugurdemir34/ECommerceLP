using Baskets.Application.Services;
using Baskets.Infrastructure.Payment;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddBasketInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
