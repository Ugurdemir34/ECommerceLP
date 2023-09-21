using Baskets.API.Extensions;
var builder = WebApplication.CreateBuilder(args).AddBasketAPI();
builder.Build().AddBasketApp().Run();