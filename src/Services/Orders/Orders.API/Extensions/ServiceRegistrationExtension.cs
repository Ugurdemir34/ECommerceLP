using Orders.Application;
using Orders.Persistence;
using ECommerceLP.Core.Serilog.Extensions;
using ECommerceLP.Core.UnitOfWork.Extensions;
using ECommerceLP.Core.ServiceDiscovery.Extensions;
using ECommerceLP.Core.CQRS.Extensions;
using Orders.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using EventBus.Base.Abstraction;
using EventBus.Base;
using EventBus.Factory;

namespace Orders.API.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static WebApplicationBuilder AddOrderAPI(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerToken();
            builder.Configuration.AddEnvironmentVariables();
            builder.Services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = builder.Configuration.GetSection(nameof(EventBusConfig)).Get<EventBusConfig>();
                return EventBusFactory.Create(config, sp);
            });
            var serviceProvider = builder.Services.BuildServiceProvider();
            builder.Services.AddUnitOfWork();
            builder.Services.AddCQRS();
            builder.Services.AddOrderPersistence(builder.Configuration);
            builder.Services.AddOrderApplication(serviceProvider);
            builder.AddSeriLog();
            var serviceConfig = builder.Configuration.GetServiceConfig();
            builder.Services.RegisterConsulServices(serviceConfig);
            builder.Services.AddHttpContextAccessor();
            return builder;
        }
        public static WebApplication AddOrderApp(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<OrderContext>();
                dbContext.Database.Migrate();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
