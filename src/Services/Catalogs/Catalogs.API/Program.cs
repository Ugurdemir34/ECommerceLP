using Catalogs.Application;
using Catalogs.Persistence;
using Catalogs.Persistence.Context;
using ECommerceLP.Application;
using ECommerceLP.Infrastructure.UnitOfWork;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCatalogPersistence(builder.Configuration);
builder.Services.AddIdentityApplication(builder.Configuration);
builder.Services.AddTransient<IUnitOfWork,UnitOfWork<CatalogContext>>();

builder.Services.AddCoreApplication();

var app = builder.Build();

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
