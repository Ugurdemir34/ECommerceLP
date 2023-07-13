using Orders.Persistence;
using Orders.Persistence.Context;
using Orders.Application;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using EventBus.Base.Abstraction;
using EventBus.Base;
using EventBus.Factory;
using Microsoft.Extensions.DependencyInjection;
using ECommerceLP.Core.UnitOfWork.Extensions;
using ECommerceLP.Core.CQRS.Extensions;
using RabbitMQ.Client;
using ECommerceLP.Core.ServiceDiscovery.Extensions;
using ECommerceLP.Core.Serilog.Extensions;
using Orders.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerToken();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddSingleton<IEventBus>(sp =>
{
    EventBusConfig config = builder.Configuration.GetSection("EventBusConfig").Get<EventBusConfig>();
    //EventBusConfig config = new()
    //{
    //    ConnectionRetryCount = 5,
    //    EventNameSuffix = "IntegrationEvent",
    //    SubscriberClientAppName = "OrderService",
    //    EventBusType = EventBusType.RabbitMQ
    //    //Connection = new ConnectionFactory()
    //    //{
    //    //    HostName = "localhost",
    //    //    Port=15762,
    //    //    UserName="guest",
    //    //    Password="guest"
    //    //}
    //};
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

//builder.Services.AddCoreApplication(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
//Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("DEVELOPMENT SUCCESS");
  
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OrderContext>();
    dbContext.Database.Migrate();
}


//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
