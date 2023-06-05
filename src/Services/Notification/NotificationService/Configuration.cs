using ECommerceLP.Application.Services;
using ECommerceLP.Application.Settings;
using ECommerceLP.Common.Mail.Models;
using ECommerceLP.Infrastructure.Mail;
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
        private const string SettingsFileName = "appsettings.json";
        public static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddOptions();
            serviceCollection.AddScoped<IMailService, MailService>();
            serviceCollection.AddTransient<OrderConfirmIntegrationEventHandler>();
            serviceCollection.AddTransient<OrderShippedIntegrationEventHandler>();
            serviceCollection.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new()
                {
                    ConnectionRetryCount = 5,
                    EventNameSuffix = "IntegrationEvent",
                    SubscriberClientAppName = "NotificationService",
                    EventBusType = EventBusType.RabbitMQ
                };
                return EventBusFactory.Create(config, sp);
            });
        }
        public static void ConfigureSettings(ServiceCollection serviceCollection)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../.."))
                          .AddJsonFile(SettingsFileName, optional: false);

            IConfiguration config = builder.Build();
            serviceCollection.AddSmtpMail(config);

            var mailSettings = config.GetSection("MailSettings").Get<SmtpSettings>();
        }
    }
}
