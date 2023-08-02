using ECommerceLP.Core.CQRS.Decorators;
using ECommerceLP.Core.Serilog.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ECommerceLP.Core.UnitOfWork.Extensions;
using ECommerceLP.Core.ServiceDiscovery.Extensions;
using ECommerceLP.Core.CQRS.Extensions;
using ECommerceLP.Core.Serialization.JSON.Extensions;
using Identity.Application;
using Identity.Persistence;
using Identity.Infrastructure;
using Identity.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using ECommerceLP.Core.Api.Middlewares;
namespace Identity.API.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static WebApplicationBuilder AddIdentityAPI(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddUnitOfWork();
            builder.Services.AddCQRS();
            builder.Services.AddIdentityApplication();
            builder.Services.AddIdentityPersistence(builder.Configuration);
            builder.Services.AddIdentityInfrastructure();
            var serviceConfig = builder.Configuration.GetServiceConfig();
            builder.Services.RegisterConsulServices(serviceConfig);
            builder.AddSeriLog();
            builder.Services.AddJwtSettings(builder.Configuration);
            builder.Services.AddJSONSerialization();
            return builder;
        }
        public static WebApplication AddIdentityApp(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
                dbContext.Database.Migrate();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCustomExceptionMiddleware();
            app.UseExceptionHandler("/error");
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
