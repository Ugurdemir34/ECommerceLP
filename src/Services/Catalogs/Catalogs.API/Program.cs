using Catalogs.API.Extensions;
var builder = WebApplication.CreateBuilder(args).AddCatalogAPI();
builder.Build().AddCatalogApp().Run();