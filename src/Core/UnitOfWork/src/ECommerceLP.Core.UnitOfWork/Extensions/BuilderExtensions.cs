using ECommerceLP.Core.Abstraction.Extensions;
using ECommerceLP.Core.Api.Exceptions.Base;
using ECommerceLP.Core.IOC;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using ECommerceLP.Core.UnitOfWork.UnitOfWork;
using Microsoft.EntityFrameworkCore;
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
                throw new ApplicationException($"ServiceCollection: {nameof(services)} not found.");
            }
            services.AddScoped(typeof(IUnitOfWork<>), typeof(ECommerceLP.Core.UnitOfWork.UnitOfWork.UnitOfWork<>));
            //services.AddScoped(typeof(IRepositoryFactory<>),
            //         provider => provider.GetService(typeof(IUnitOfWork<>)));

            var discovery = AssemblyDiscovery.GetInstance();
            foreach (var assembly in discovery.RepositoryAssemblies)
            {
                var contexts = assembly.GetTypes()
                                       .Where(x => x.IsSubclassOf(typeof(DbContext)))
                                       .ToList();

                foreach (var context in contexts)
                {
                    var svcType = typeof(IUnitOfWork<>).MakeGenericType(context);
                    var impType = typeof(UnitOfWork<>).MakeGenericType(context);

                    //var svcType2 = typeof(IRepositoryFactory<>).MakeGenericType(context);
                    services.AddScoped(svcType, impType);
                    services.AddScoped(typeof(IUnitOfWork), impType);
                    //services.AddScoped(svcType2, impType);
                }

            }
            services.ToScan(scan => scan.FromAssemblies(discovery.RepositoryAssemblies)
                                      .AddClasses(x => x.AssignableTo(typeof(ICustomRepository)))
                                      .AsImplementedInterfaces()
                                      .WithScopedLifetime());

            return services;
        }
    }
}
