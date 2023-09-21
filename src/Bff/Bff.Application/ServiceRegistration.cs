using Bff.Application.Identity.Command.LoginUser;
using Identity.Common.Dtos;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Application
{
    public static class ServiceRegistration
    {
        public static void AddBffIdentityApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Bff.Application"));
            });
            serviceCollection.AddScoped<IRequestHandler<LoginUserCommand, LoginDto>, LoginUserCommandHandler>();
        }
    }
}
