using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IConfiguration config = new ConfigurationBuilder()
                       .AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(config).AddConsul();
//var app = builder.Build();
var app = new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureAppConfiguration((context, config) =>
    {
        config.SetBasePath(context.HostingEnvironment.ContentRootPath)
        .AddJsonFile("appsetting.json", true, true)
        .AddJsonFile("ocelot.json")
        .AddEnvironmentVariables();
    })
    .ConfigureServices(s =>
    {
        s.AddOcelot().AddConsul();
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        logging.AddConsole();
    })
    .UseIISIntegration()
    .Configure(APP =>
    {
        APP.UseOcelot();
    })
    .Build();

app.Run();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

////app.UseHttpsRedirection();

//app.UseOcelot().GetAwaiter().GetResult();
//app.UseAuthorization();

//app.MapControllers();

//app.Run();
