using EventBus.Base.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using NotificationService;
using NotificationService.IntegrationEvents.EventHandlers;
using NotificationService.IntegrationEvents.Events;
using System.Runtime.Loader;

ManualResetEvent quitEvet = new ManualResetEvent(false);

Console.CancelKeyPress += (sender, args) =>
{
    quitEvet.Set();
    args.Cancel = true;
};
ServiceCollection services = new ServiceCollection();

var configuration = Configuration.ConfigureSettings(services);
Configuration.ConfigureServices(services, configuration);

var sp = services.BuildServiceProvider();
IEventBus eventBus = sp.GetRequiredService<IEventBus>();
eventBus.Subscribe<OrderConfirmIntegrationEvent, OrderConfirmIntegrationEventHandler>();
eventBus.Subscribe<OrderShippedIntegrationEvent, OrderShippedIntegrationEventHandler>();
eventBus.Subscribe<PaymentCompletedIntegrationEvent, PaymentCompletedEventHandler>();
Console.WriteLine("Notification service has been started...");
Console.ReadLine();

quitEvet.WaitOne();

