using ECommerceLP.Common.Mail.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Extensions
{
    public static class MimeMessageExtensions
    {
        public static MimeMessage CreateMimeMessage(
            this EMailMessage mailMessage,
            string defaultFromAddress,
            string defaultFromDisplayName)
        {
            var sender = new MailboxAddress(
                mailMessage.From?.DisplayName ?? defaultFromDisplayName,
                mailMessage.From?.Address ?? defaultFromAddress);
            var message = new MimeMessage()
            {
                Subject = mailMessage.Subject,
                Sender = sender
            };
            message.From.Add(sender);

            foreach (var toAddress in mailMessage.Tos)
            {
                message.To.Add(new MailboxAddress(toAddress.DisplayName, toAddress.Address));
            }

            foreach (var ccAddress in mailMessage.CCs)
            {
                message.Cc.Add(new MailboxAddress(ccAddress.DisplayName, ccAddress.Address));
            }

            foreach (var bccAddress in mailMessage.BCCs)
            {
                message.Bcc.Add(new MailboxAddress(bccAddress.DisplayName, bccAddress.Address));
            }

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = mailMessage.Body;


            foreach (var attachment in mailMessage.Attachments)
            {
                bodyBuilder.Attachments.Add(attachment.FileName, attachment.Stream);
            }

            message.Body = bodyBuilder.ToMessageBody();
            return message;
        }
    }
}
