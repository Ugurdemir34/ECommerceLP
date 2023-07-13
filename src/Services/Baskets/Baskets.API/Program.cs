using Baskets.Application;
using Baskets.Domain.Repositories;
using Baskets.Persistence;
using Baskets.Persistence.Contexts;
using Baskets.Persistence.Repositories;
using ECommerceLP.Core.UnitOfWork.Extensions;
using ECommerceLP.Core.Serialization.JSON;
using Microsoft.EntityFrameworkCore;
using Baskets.Infrastructure;
using ECommerceLP.Core.Serialization.JSON.Extensions;
using ECommerceLP.Core.CQRS.Extensions;
using ECommerceLP.Core.ServiceDiscovery.Extensions;
using ECommerceLP.Core.Serilog.Extensions;
using ECommerceLP.Core.Mongo.Extensions;
using ECommerceLP.Core.Abstraction.Settings;
using Baskets.API.Extensions;
using Microsoft.Extensions.DependencyInjection;
using EventBus.Base.Abstraction;
using EventBus.Base;
using EventBus.Factory;
using Baskets.Domain.Aggregate.BasketAggregate.IntegrationEvents.Events;
using Baskets.Persistence.EventHandlers;
using ECommerceLP.Core.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
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
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCustomExceptionMiddleware();
app.UseExceptionHandler("/error");
app.UseAuthorization();

app.MapControllers();

app.Run();
