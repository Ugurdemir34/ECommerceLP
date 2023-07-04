using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Builder;

namespace ECommerceLP.Core.Serilog.Extensions
{
    public static class SerilogExtensions
    {
        public static WebApplicationBuilder AddSeriLog(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });
            return builder;
        }
    }
}
