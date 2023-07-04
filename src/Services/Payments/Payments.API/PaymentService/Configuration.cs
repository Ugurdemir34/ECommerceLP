using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.IntegrationEvents.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService
{
    public class Configuration
    {
        private const string SettingsFileName = "appsettings.json";
        public static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<PaymentProcessedEventHandler>();
            serviceCollection.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new()
                {
                    ConnectionRetryCount = 5,
                    EventNameSuffix = "IntegrationEvent",
                    SubscriberClientAppName = "PaymentService",
                    EventBusType = EventBusType.RabbitMQ
                };
                return EventBusFactory.Create(config, sp);
            });
        }
    }
}
