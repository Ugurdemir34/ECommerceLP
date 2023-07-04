using EventBus.Base.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using PaymentService;
using PaymentService.IntegrationEvents.EventHandlers;
using PaymentService.IntegrationEvents.Events;

ServiceCollection services = new ServiceCollection();

Configuration.ConfigureServices(services);
var sp = services.BuildServiceProvider();
IEventBus eventBus = sp.GetRequiredService<IEventBus>();
eventBus.Subscribe<PaymentProcessedIntegrationEvent, PaymentProcessedEventHandler>();
Console.WriteLine("Payment service has been started...");
Console.ReadKey();
