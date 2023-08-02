using Orders.API.Extensions;
var builder = WebApplication.CreateBuilder(args).AddOrderAPI();
builder.Build().AddOrderApp().Run();