using Orders.API.Extensions;
var builder = WebApplication.CreateBuilder(args).AddProductAPI();
builder.Build().AddProductApp().Run();