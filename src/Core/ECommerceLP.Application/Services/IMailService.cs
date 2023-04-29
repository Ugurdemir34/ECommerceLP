using ECommerceLP.Application.Settings;
using ECommerceLP.Common.Mail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Services
{
    public interface IMailService
    {
        Task SendMailAsync(EMailMessage message, MailCredential? credential = null, CancellationToken cancellationToken = default);
    }
}
