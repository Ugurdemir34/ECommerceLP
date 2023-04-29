using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Mail.Models
{
    public class MailCredential
    {
        public string User { get; set; }
        public string Password { get; set; }
        public MailCredential(string user, string password)
        {
            this.User = user;
            this.Password = password;
        }
    }
}
