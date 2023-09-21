using Bff.Application.Identity.Command;
using ECommerceLP.Core.CQRS.Extensions;
using Identity.Common.Dtos;
using MediatR;
using ECommerceLP.Core.RemoteCall.Extensions;
using Bff.Application;
using ECommerceLP.Core.Serialization.JSON.Extensions;
using ECommerceLP.Core.Api.Middlewares;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddRemoteCall();
builder.Services.AddCQRS();
builder.Services.AddBffIdentityApplication();

builder.Services.AddJSONSerialization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustomExceptionMiddleware();
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
