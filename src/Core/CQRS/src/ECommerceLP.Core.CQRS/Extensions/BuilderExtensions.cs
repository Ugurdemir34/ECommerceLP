using ECommerceLP.Core.Abstraction.Exception;
using ECommerceLP.Core.Abstraction.Extensions;
using ECommerceLP.Core.CQRS.Abstraction;
using ECommerceLP.Core.CQRS.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.CQRS.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ApplicationException($"ServiceCollection: {nameof(services)} not found.");

            }
            services.AddScoped(typeof(IProcessor), typeof(Processor));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
