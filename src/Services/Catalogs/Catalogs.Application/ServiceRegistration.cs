using Catalogs.Application.CQRS.Category.Queries.GetCategories;
using Catalogs.Common.Dtos;
using ECommerceLP.Application.Repositories;
using ECommerceLP.Common.Collections.Abstract;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Application
{
    public static class ServiceRegistration
    {
        public static void AddIdentityApplication(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Catalogs.Application"));
            });
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.Load("Catalogs.Application"));
            serviceCollection.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            serviceCollection.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            serviceCollection.AddScoped<IRequestHandler<GetCategoriesQuery, IPagedList<CategoryDto>>, GetCategoriesQueryHandler>();

        }
    }
}
