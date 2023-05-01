using ECommerceLP.Application.CQRS.Concrete;
using ECommerceLP.Application.Decorators;
using ECommerceLP.Application.Extensions;
using ECommerceLP.Application.Pipelines;
using ECommerceLP.Common.Collections.Abstract;
using ECommerceLP.Common.Collections.Concrete;
using ECommerceLP.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application
{
    public static class ServiceRegistration
    {
        public static void AddCoreApplication(this IServiceCollection serviceCollection,IConfiguration configuration)
        {
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            foreach (var serviceType in typeof(Processor).GetInterfaces())
            {
                serviceCollection.AddScoped(serviceType, typeof(Processor));
            }
            serviceCollection.AddScoped(typeof(IPagedList<>), typeof(PagedList<>));
            serviceCollection.AddRedis(configuration);
            //serviceCollection.AddScoped(typeof(CommandHandlerDecorator<,>));
        }
    }
}
