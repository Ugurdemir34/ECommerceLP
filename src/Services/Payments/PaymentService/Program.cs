using Baskets.Domain.Aggregate.BasketAggregate;
using ECommerceLP.Core.Mongo.Abstractions;
using EventBus.Base.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Payment.Domain.Aggregate.PaymentAggregates.IntegrationEvents.Events;
using PaymentService;
using PaymentService.IntegrationEvents.EventHandlers;
using PaymentService.IntegrationEvents.Events;


ManualResetEvent quitEvet = new ManualResetEvent(false);

Console.CancelKeyPress += (sender, args) =>
{
    quitEvet.Set();
    args.Cancel = true;
};
ServiceCollection services = new ServiceCollection();

var config = Configuration.ConfigureSettings(services);
Configuration.ConfigureServices(services, config);
var sp = services.BuildServiceProvider();

IEventBus eventBus = sp.GetRequiredService<IEventBus>();
eventBus.Subscribe<PaymentProcessedIntegrationEvent, PaymentProcessedIntegrationEventHandler>();
eventBus.Subscribe<BasketBuyStartedIntegrationEvent, BasketBuyStartedIntegrationEventHandler>();
Console.WriteLine("Payment service has been started...");
Console.ReadLine();
quitEvet.WaitOne();
