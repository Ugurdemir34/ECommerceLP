using ECommerceLP.Core.Api.Exceptions.Base;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.UnitOfWork.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new CustomException($"ServiceCollection: {nameof(services)} not found.");
            }
            services.AddScoped(typeof(IUnitOfWork), typeof(ECommerceLP.Core.UnitOfWork.UnitOfWork.UnitOfWork));
        }
    }
}
