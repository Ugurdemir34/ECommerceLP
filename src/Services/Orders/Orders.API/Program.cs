using ECommerceLP.Application;
using ECommerceLP.Infrastructure;
using Orders.Persistence;
using Orders.Persistence.Context;
using Orders.Application;
using ECommerceLP.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOrderPersistence(builder.Configuration);
builder.Services.AddOrderApplication();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork<OrderContext>>();

builder.Services.AddCoreApplication();


var app = builder.Build();
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
