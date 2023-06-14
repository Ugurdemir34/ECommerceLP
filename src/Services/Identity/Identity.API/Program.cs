using Identity.API.Extensions;
using Identity.Application;
using Identity.Persistence.Context;
using Identity.Persistence;
using ECommerceLP.Application;
using Identity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ECommerceLP.Core.UnitOfWork.Extensions;
using ECommerceLP.Core.CQRS.Extensions;
using ECommerceLP.Core.Serialization.JSON.Extensions;
using ECommerceLP.Core.Api.Middlewares;
var builder = WebApplication.CreateBuilder(args);
var conf = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddUnitOfWork();
builder.Services.AddCQRS();
builder.Services.AddIdentityApplication();
builder.Services.AddIdentityPersistence(builder.Configuration);
builder.Services.AddIdentityInfrastructure();

//builder.Services.AddCoreApplication(builder.Configuration);
builder.Services.AddJwtSettings(conf);
builder.Services.AddJSONSerialization();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExceptionMiddleware();
app.UseExceptionHandler("/Error");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
