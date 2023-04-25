﻿using Identity.Application.Common.Abstracts;
using Identity.Application.Common.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthentication, AuthenticationService>();
        }
    }
}