using ECommerceLP.Application.Services;
using ECommerceLP.Application.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Infrastructure.Mail
{
    public static class MailExtensions
    {
        public static IServiceCollection AddSmtpMail(
            this IServiceCollection services,
            IConfiguration config,
            Action<SmtpSettings> settings = null)
        {
            services.AddSingleton<IMailService, MailService>();

            if (settings != null)
            {
                services.Configure(settings);
            }
            else
            {
                services.Configure<SmtpSettings>(config.GetSection("SmtpSettings"));
            }

            return services;
        }
    }
}
