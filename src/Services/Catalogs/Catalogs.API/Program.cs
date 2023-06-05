using Catalogs.Application;
using Catalogs.Persistence;
using Catalogs.Persistence.Context;
using ECommerceLP.Application;
using ECommerceLP.Application.Decorators;
using ECommerceLP.Application.Services;
using ECommerceLP.Infrastructure.Cache;
using ECommerceLP.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCatalogPersistence(builder.Configuration);
builder.Services.AddIdentityApplication(builder.Configuration);
builder.Services.AddTransient<IUnitOfWork, UnitOfWork<CatalogContext>>();
builder.Services.AddScoped<ICacheService, RedisService>();
builder.Services.AddCoreApplication(builder.Configuration);
//builder.Services.Decorate(typeof(IRequestHandler<,>), typeof(QueryHandlerDecorator<,>));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CatalogContext>();
    dbContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
