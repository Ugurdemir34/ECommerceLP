using Products.Persistence;
using ECommerceLP.Core.ServiceDiscovery.Extensions;
using Microsoft.EntityFrameworkCore;
using Products.Persistence.Context;

namespace Orders.API.Extensions
{
    public static class ServiceRegistrationExtension
    {
        public static WebApplicationBuilder AddProductAPI(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddProductPersistence(builder.Configuration);
            var serviceConfig = builder.Configuration.GetServiceConfig();
            builder.Services.RegisterConsulServices(serviceConfig);
            return builder;
        }
        public static WebApplication AddProductApp(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ProductContext>();
                dbContext.Database.Migrate();
            }
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
