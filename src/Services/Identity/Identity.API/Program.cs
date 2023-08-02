using Identity.API.Extensions;
var builder = WebApplication.CreateBuilder(args).AddIdentityAPI();
builder.Build().AddIdentityApp().Run();