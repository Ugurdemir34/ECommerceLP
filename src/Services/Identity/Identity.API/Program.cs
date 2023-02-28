using Identity.API.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using Identity.Infrastructure.Context;
using ECommerceLP.Application.Repositories;
using ECommerceLP.Infrastructure.UnitOfWork;
using MediatR;
using Identity.Application.CQRS.Commands;
using Identity.Common.Dtos;
using Identity.Application.CQRS.Handlers.CommandHandlers;
using Identity.Application.Common.Abstracts;
using Identity.Application.Common.Concretes;
using Identity.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var conf = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserContext>(opt => opt.UseSqlServer(@"Server=DESKTOP-5D8FOCF\UGUR;Database=ECommerceDB;Trusted_Connection=True;Encrypt=False"));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("Identity.Application"));
});
//builder.Services.AddAutoMapper();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.Load("Identity.Application"));
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddScoped<IAuthentication, AuthenticationService>();
builder.Services.AddTransient<IUnitOfWork,UnitOfWork<UserContext>>();
builder.Services.AddJwtSettings(conf);
builder.Services.AddScoped<IRequestHandler<CreateUserCommand,CreateUserDTO>,CreateUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<LoginUserCommand,LoginDto>,LoginUserCommandHandler>();
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
