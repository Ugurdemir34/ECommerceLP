using ECommerceLP.Infrastructure.UnitOfWork;
using Identity.API.Extensions;
using Identity.Application;
using Identity.Persistence.Context;
using Identity.Persistence;
using ECommerceLP.Application;
using ECommerceLP.Common.Json.Extensions;
using Identity.Infrastructure;
var builder = WebApplication.CreateBuilder(args);
var conf = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityApplication();
builder.Services.AddIdentityPersistence(builder.Configuration);
builder.Services.AddIdentityInfrastructure();

builder.Services.AddCoreApplication();
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
//foreach (var serviceType in typeof(Processor).GetInterfaces())
//{
//    builder.Services.AddScoped(serviceType, typeof(Processor));
//}
builder.Services.AddTransient<IUnitOfWork, UnitOfWork<UserContext>>();
builder.Services.AddJwtSettings(conf);
builder.Services.AddJSONSerialization();
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
