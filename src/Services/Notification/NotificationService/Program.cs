using EventBus.Base.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using NotificationService;
using NotificationService.IntegrationEvents.EventHandlers;
using NotificationService.IntegrationEvents.Events;

ServiceCollection services = new ServiceCollection();

Configuration.ConfigureServices(services);
Configuration.ConfigureSettings(services);
var sp = services.BuildServiceProvider();
IEventBus eventBus = sp.GetRequiredService<IEventBus>();
eventBus.Subscribe<OrderConfirmIntegrationEvent, OrderConfirmIntegrationEventHandler>();
Console.WriteLine("Notification service has been started...");
Console.ReadLine();