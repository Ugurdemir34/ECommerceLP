using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceLP.Core.Abstraction;
using ECommerceLP.Core.Abstraction.Extensions;
using ECommerceLP.Core.IOC;
using ECommerceLP.Core.Mongo.Abstractions;

namespace ECommerceLP.Core.Mongo.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ApplicationException($"ServiceCollection: {nameof(services)} not found.");
            }

            services.AddScoped(typeof(IMongoRepositoryFactory<>), typeof(MongoRepositoryFactory<>));

            var moduleDiscovery = AssemblyDiscovery.GetInstance();
            services.ToScan(scan => scan.FromAssemblies(moduleDiscovery.RepositoryAssemblies)
                .AddClasses(x => x.AssignableTo(typeof(MongoContext)))
                .As<MongoContext>()
                .AsSelf()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            foreach (var assembly in moduleDiscovery.RepositoryAssemblies)
            {
                var dbContexts = assembly.GetTypes()
                    .Where(x => x.IsSubclassOf(typeof(MongoContext)))
                    .ToList();

                foreach (var dbContext in dbContexts)
                {
                    var serviceType = typeof(IMongoRepositoryFactory<>).MakeGenericType(dbContext);
                    var implementationType = typeof(MongoRepositoryFactory<>).MakeGenericType(dbContext);

                    services.AddScoped(serviceType, implementationType);
                }
            }

            return services;
        }
    }
}
