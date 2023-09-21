using Baskets.Application.CQRS.BasketItems.Commands.CreateBasketItem;
using Baskets.Application.CQRS.BasketItems.Commands.DeleteBasketItem;
using Baskets.Application.CQRS.Baskets.Commands.BuyBasket;
using Baskets.Application.CQRS.Baskets.Commands.CreateBasket;
using Baskets.Common.Dtos;
using Baskets.Domain.Repositories;
using EventBus.Base.Abstraction;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace Baskets.Application
{
    public static class ServiceRegistration
    {
        public static void AddBasketApplication(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Baskets.Application"));
            });
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.Load("Baskets.Application"));
            //serviceCollection.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            //serviceCollection.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            serviceCollection.AddScoped<IRequestHandler<CreateBasketCommand, BasketDto>, CreateBasketCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<BuyBasketCommand, BasketDto>, BuyBasketCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<AddBasketItemCommand, BasketItemDto>, AddBasketItemCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteBasketItemCommand, bool>, DeleteBasketItemCommandHandler>();
            //serviceCollection.AddValidatorsFromAssemblyContaining<CreateOrderCommandValidator>();
        }
    }
}
