using ECommerceLP.Application.Services;
using ECommerceLP.Application.Settings;
using ECommerceLP.Common.Mail.Models;

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceLP.Common.Extensions;
using DotNetCore.CAP;
using System.Net.Mail;
using System.Net;

namespace ECommerceLP.Infrastructure.Mail
{
    public class MailService : IMailService
    {
        private readonly IOptionsMonitor<SmtpSettings> _options;
        public MailService(IOptionsMonitor<SmtpSettings> options)
        {
            _options = options;
        }
        public Task SendMailAsync(EMailMessage message, MailCredential credential = null, CancellationToken cancellationToken = default)
        {
            try
            {
                var fromAddress = new MailAddress("ugurrdemirr34@yandex.com", "Ugur");
                var toAddress = new MailAddress("ugurdemir551@gmail.com", "udemir");
                const string fromPassword = "ugurdemir2434./*+";
                const string subject = "Subject";
                const string body = "Body";

                var smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.yandex.com",
                    Port = 587,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                var msg = new MailMessage("ugurrdemirr34@yandex.com", "ugurdemir551@gmail.com", subject, body);


                smtp.Send(msg);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage1(): {0}",
                            ex.ToString());
            }
            return default;
        }

        //public async Task SendMailAsync(MailMessage message,
        //                          MailCredential credential = null,
        //                          CancellationToken cancellationToken = default)
        //{
        //    SmtpClient client;
        //    if (credential != null)
        //    {
        //        client = await this.GetClientAsync(
        //            credential.User,
        //            credential.Password,
        //            cancellationToken);
        //    }
        //    else
        //    {
        //        client = await this.GetClientAsync(
        //            this._options.CurrentValue.DefaultUsername,
        //            this._options.CurrentValue.DefaultPassword,
        //            cancellationToken);
        //    }

        //    await client.SendAsync(
        //        message.CreateMimeMessage(
        //            this._options.CurrentValue.DefaultSender,
        //            this._options.CurrentValue.DefaultSenderDisplayName),
        //        cancellationToken);
        //}
        //private async Task<SmtpClient> GetClientAsync(
        //    string userName,
        //    string password,
        //    CancellationToken cancellationToken)
        //{
        //    var currentClient = new SmtpClient();
        //    await currentClient.ConnectAsync(
        //        this._options.CurrentValue.Server,
        //        this._options.CurrentValue.Port,
        //        this._options.CurrentValue.UseSsl,
        //        cancellationToken);

        //    var aa = currentClient.IsConnected;
        //    currentClient.Authenticate(
        //       userName,
        //       password,
        //       cancellationToken);

        //    return currentClient;
        //}
    }
}
