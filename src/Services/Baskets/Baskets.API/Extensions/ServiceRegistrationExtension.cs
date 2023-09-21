using Baskets.Persistence.EventHandlers;
using ECommerceLP.Core.Abstraction.Settings;
using EventBus.Base.Abstraction;
using EventBus.Base;
using EventBus.Factory;
using ECommerceLP.Core.Serialization.JSON.Extensions;
using ECommerceLP.Core.CQRS.Extensions;
using ECommerceLP.Core.Mongo.Extensions;
using ECommerceLP.Core.Serilog.Extensions;
using ECommerceLP.Core.ServiceDiscovery.Extensions;
using Baskets.Domain.Aggregate.BasketAggregate.IntegrationEvents.Events;
using Baskets.Application;
using ECommerceLP.Core.Api.Middlewares;
namespace Baskets.API.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static WebApplicationBuilder AddBasketAPI(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCQRS();
            builder.Services.AddJSONSerialization();
            builder.Services.AddOptions<DatabaseSettings>().Bind(builder.Configuration.GetSection("DatabaseSettings"));
            builder.Services.AddMongo();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<BasketBuyCompletedIntegrationEventHandler>();
            builder.Services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = builder.Configuration.GetSection(nameof(EventBusConfig)).Get<EventBusConfig>();
                return EventBusFactory.Create(config, sp);
            });
            var serviceProvider = builder.Services.BuildServiceProvider();
            builder.Services.AddBasketApplication();
            builder.Services.AddJwtSettings(builder.Configuration);
            IEventBus eventBus = serviceProvider.GetRequiredService<IEventBus>();
            eventBus.Subscribe<BasketBuyCompletedIntegrationEvent, BasketBuyCompletedIntegrationEventHandler>();
            builder.AddSeriLog();
            var serviceConfig = builder.Configuration.GetServiceConfig();
            builder.Services.RegisterConsulServices(serviceConfig);
            return builder;
        }
        public static WebApplication AddBasketApp(this WebApplication app)
        {
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
