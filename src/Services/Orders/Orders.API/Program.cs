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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
 {
     {
           new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
             },
            new string[] {}
        }
 });
});
//builder.Services.AddTransient<OrderConfirmIntegrationEventHandler>();
builder.Services.AddSingleton<IEventBus>(sp =>
{
    EventBusConfig config = new()
    {
        ConnectionRetryCount = 5,
        EventNameSuffix = "IntegrationEvent",
        SubscriberClientAppName = "OrderService",
        EventBusType = EventBusType.RabbitMQ
    };
    return EventBusFactory.Create(config, sp);
});
var serviceProvider = builder.Services.BuildServiceProvider();
builder.Services.AddUnitOfWork();
builder.Services.AddCQRS();
builder.Services.AddOrderPersistence(builder.Configuration);
builder.Services.AddOrderApplication(serviceProvider);
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork<OrderContext>>();

//builder.Services.AddCoreApplication(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OrderContext>();
    dbContext.Database.Migrate();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
