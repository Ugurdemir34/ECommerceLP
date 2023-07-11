using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.IntegrationEvents.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService
{
    public class Configuration
    {
        public static void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<OrderConfirmIntegrationEventHandler>();
            serviceCollection.AddTransient<OrderShippedIntegrationEventHandler>();
            serviceCollection.AddTransient<PaymentCompletedEventHandler>();
            serviceCollection.AddSingleton<IEventBus>(sp =>
            {
                //EventBusConfig config = new()
                //{
                //    ConnectionRetryCount = 5,
                //    EventNameSuffix = "IntegrationEvent",
                //    SubscriberClientAppName = "NotificationService",
                //    EventBusType = EventBusType.RabbitMQ,
                //    Host=
                //};
                EventBusConfig econfig = configuration.GetSection("EventBusConfig").Get<EventBusConfig>();
                return EventBusFactory.Create(econfig, sp);
            });
        }
        public static IConfiguration ConfigureSettings(ServiceCollection serviceCollection)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                         .AddJsonFile($"appsettings.{env}.json", optional: true)
                         .AddEnvironmentVariables();
            IConfiguration config = builder.Build();
            return config;
        }
    }
}
