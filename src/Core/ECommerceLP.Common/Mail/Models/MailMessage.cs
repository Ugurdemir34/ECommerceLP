using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Mail.Models
{
    public class EMailMessage : MailMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<MailAttachment> Attachments { get; set; }
        public EMailAddress From { get; set; }
        public List<EMailAddress> Tos { get; set; }
        public List<EMailAddress> CCs { get; set; }
        public List<EMailAddress> BCCs { get; set; }
        public EMailMessage()
        {
            this.Tos = new List<EMailAddress>();
            this.CCs = new List<EMailAddress>();
            this.BCCs = new List<EMailAddress>();
            this.Attachments = new List<MailAttachment>();
        }
    }
}
