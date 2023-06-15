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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCoreApplication(builder.Configuration);
builder.Services.AddUnitOfWork();
builder.Services.AddJSONSerialization();
builder.Services.AddBasketPersistence(builder.Configuration);
builder.Services.AddBasketApplication();
builder.Services.AddBasketInfrastructure();
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork<BasketContext>>();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BasketContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();