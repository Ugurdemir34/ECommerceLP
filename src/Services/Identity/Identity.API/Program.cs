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
using ECommerceLP.Core.FileLogging;
using ECommerceLP.Core.FileLogging.Extensions;
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

string contentRoot = builder.Services.BuildServiceProvider()
                             .GetService<Microsoft.AspNetCore.Hosting.IHostingEnvironment>()
                             .ContentRootPath;


builder.Services.AddLogging(loggingBuilder =>
{
    var loggingSection = builder.Configuration.GetSection("Logging");
    loggingBuilder.AddConfiguration(loggingSection);
    loggingBuilder.AddConsole();

    Action<FileLoggerOptions> resolveRelativeLoggingFilePath = (fileOpts) =>
    {
        fileOpts.FormatLogFileName = fName =>
        {
            return Path.IsPathRooted(fName) ? fName : Path.Combine(contentRoot, fName);
        };
    };

    loggingBuilder.AddFile(loggingSection.GetSection("FileOne"), resolveRelativeLoggingFilePath);

    // alternatively, you can configure 2nd file logger (or both) in the code:
    /*loggingBuilder.AddFile("logs/app_debug.log", (fileOpts) => {
        fileOpts.MinLevel = LogLevel.Debug;
        resolveRelativeLoggingFilePath(fileOpts);
    });*/

});

















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
