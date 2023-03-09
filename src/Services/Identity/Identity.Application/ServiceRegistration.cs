﻿using ECommerceLP.Application.Repositories;
using FluentValidation;
using Identity.Application.Common.Abstracts;
using Identity.Application.Common.Concretes;
using Identity.Application.CQRS.User.Commands.CreateUser;
using Identity.Application.CQRS.User.Commands.LoginUser;
using Identity.Common.Dtos;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application
{
    public static class ServiceRegistration
    {
        public static void AddIdentityApplication(this IServiceCollection serviceCollection, IConfiguration configuration=null)
        {
            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Identity.Application"));
            });
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.Load("Identity.Application"));
            serviceCollection.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            serviceCollection.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            serviceCollection.AddScoped<IAuthentication, AuthenticationService>();
            serviceCollection.AddScoped<IRequestHandler<CreateUserCommand, CreateUserDTO>, CreateUserCommandHandler>();
            serviceCollection.AddScoped<IRequestHandler<LoginUserCommand, LoginDto>, LoginUserCommandHandler>();
            serviceCollection.AddValidatorsFromAssemblyContaining<LoginUserCommandValidator>();

        }
    }
}
