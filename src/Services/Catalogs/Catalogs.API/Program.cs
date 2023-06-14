using Catalogs.Application;
using Catalogs.Persistence;
using Catalogs.Persistence.Context;
using ECommerceLP.Application;
using ECommerceLP.Application.Decorators;
using ECommerceLP.Application.Services;
using ECommerceLP.Infrastructure.Cache;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ECommerceLP.Core.CQRS.Extensions;
using ECommerceLP.Core.UnitOfWork.Extensions;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using ECommerceLP.Core.UnitOfWork.UnitOfWork;
using ECommerceLP.Core.CQRS.Abstraction;
using ECommerceLP.Core.CQRS;
using ECommerceLP.Common.Collections.Abstract;
using ECommerceLP.Common.Collections.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCQRS();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Catalogs.Application"));
});
builder.Services.AddUnitOfWork();
builder.Services.AddCatalogPersistence(builder.Configuration);
builder.Services.AddCatalogApplication(builder.Configuration);
//builder.Services.AddTransient(typeof(IUnitOfWork<CatalogContext>), typeof(UnitOfWork<CatalogContext>));
//builder.Services.AddScoped<ICacheService, RedisService>();
//builder.Services.AddCoreApplication(builder.Configuration);
//builder.Services.Decorate(typeof(IRequestHandler<,>), typeof(QueryHandlerDecorator<,>));
//builder.Services.AddScoped(typeof(IRepositoryFactory<CatalogContext>), typeof(IUnitOfWork<CatalogContext>));
//builder.Services.AddTransient<IRepositoryFactory<CatalogContext>, UnitOfWork<CatalogContext>>();
//builder.Services.AddTransient<IUnitOfWork<CatalogContext>, UnitOfWork<CatalogContext>>();
//builder.Services.AddScoped(typeof(IPagedList<>), typeof(PagedList<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.Load("Catalogs.Application"));
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
