using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Mail.Models
{
    public class MailAttachment
    {
        public string FileName { get; set; }
        public Stream Stream { get; set; }
        public MailAttachment(string fileName,Stream stream)
        {
            this.FileName = fileName;
            this.Stream = stream;
        }
    }
}
