using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Settings
{
    public static class RabbitMQExtensions
    {
        public static void AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCap(r =>
            {
                r.UseRabbitMQ(opt =>
                {
                    opt.HostName = configuration["CAP:RabbitMQ:HostName"];
                    opt.UserName = configuration["CAP:RabbitMQ:UserName"];
                    opt.Password = configuration["CAP:RabbitMQ:Password"];
                    opt.VirtualHost = configuration["CAP:RabbitMQ:VirtualHost"];
                    opt.Port = int.Parse(configuration["CAP:RabbitMQ:Port"]);
                    opt.ConnectionFactoryOptions = opt =>
                    {
                        opt.HostName = configuration["CAP:RabbitMQ:HostName"];
                        opt.Port = int.Parse(configuration["CAP:RabbitMQ:Port"]);
                        opt.UserName = "guest";
                        opt.Password = "guest";
                    };
                });
                r.UseSqlServer(configuration["CAP:SqlServer"]);
                r.UseDashboard();
            });
        }
    }
}
