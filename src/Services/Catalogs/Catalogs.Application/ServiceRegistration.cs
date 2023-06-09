using Catalogs.Application.CQRS.Category.Command.CreateCategory;
using Catalogs.Application.CQRS.Category.Command.DeleteCategory;
using Catalogs.Application.CQRS.Category.Queries.GetCategories;
using Catalogs.Application.CQRS.Category.Queries.GetCategoryById;
using Catalogs.Common.Dtos;
using ECommerceLP.Application.Decorators;
using ECommerceLP.Application.Repositories;
using ECommerceLP.Common.Collections.Abstract;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ECommerceLP.Core.Abstraction.Collections;

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
            serviceCollection.AddScoped<IRequestHandler<GetCategoriesQuery, PagedList<CategoryDto>>, GetCategoriesQueryHandler>();
            serviceCollection.AddScoped<IRequestHandler<GetCategoryByIdQuery, CategoryDto>, GetCategoryByIdHandler>();
            serviceCollection.AddScoped<IRequestHandler<CreateCategoryCommand, CategoryDto>, CreateCategoryHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteCategoryCommand, bool>, DeleteCategoryHandler>();
            serviceCollection.AddValidatorsFromAssemblyContaining<GetCategoryByIdValidator>();
            serviceCollection.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
            serviceCollection.AddValidatorsFromAssemblyContaining<DeleteCategoryValidator>();
            serviceCollection.Decorate(typeof(IRequestHandler<,>), typeof(QueryHandlerDecorator<,>));
        }
    }
}
