﻿using ECommerceLP.Application.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.CQRS.Orders.Commands.CreateOrder;
using Orders.Application.CQRS.Orders.Commands.DeleteOrder;
using Orders.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application
{
    public static class ServiceRegistration
    {
        public static void AddOrderApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Orders.Application"));
            });
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.Load("Orders.Application"));
            serviceCollection.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            serviceCollection.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            serviceCollection.AddScoped<IRequestHandler<CreateOrderCommand, OrderDto>, CreateOrderCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<HardDeleteOrderCommand, bool>, HardDeleteOrderCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<DeleteOrderCommand, bool>, DeleteOrderCommandHandler>();
            serviceCollection.AddValidatorsFromAssemblyContaining<CreateOrderCommandValidator>();
        }
    }
}