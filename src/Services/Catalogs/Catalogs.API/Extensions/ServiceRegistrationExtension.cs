using Catalogs.Application;
using Catalogs.Persistence;
using ECommerceLP.Core.CQRS.Decorators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ECommerceLP.Core.Cache.Redis.Extensions;
using ECommerceLP.Core.Serilog.Extensions;
using ECommerceLP.Core.UnitOfWork.Extensions;
using ECommerceLP.Core.ServiceDiscovery.Extensions;
using ECommerceLP.Core.CQRS.Extensions;
using Catalogs.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalogs.API.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static WebApplicationBuilder AddCatalogAPI(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRedis(builder.Configuration);
            builder.AddSeriLog();
            builder.Services.AddCQRS();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Catalogs.Application"));
            });
            builder.Services.AddUnitOfWork();
            builder.Services.AddCatalogPersistence(builder.Configuration);
            builder.Services.AddCatalogApplication(builder.Configuration);
            builder.Services.Decorate(typeof(IRequestHandler<,>), typeof(CacheQueryHandlerDecorator<,>));

            var serviceConfig = builder.Configuration.GetServiceConfig();
            builder.Services.RegisterConsulServices(serviceConfig);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.Load("Catalogs.Application"));
            return builder;
        }
        public static WebApplication AddCatalogApp(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CatalogContext>();
                dbContext.Database.Migrate();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
