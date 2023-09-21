using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Settings
{
    public class SmtpSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }

        public string DefaultSender { get; set; }
        public string DefaultSenderDisplayName { get; set; }

        public string DefaultUsername { get; set; }
        public string DefaultPassword { get; set; }
    }
}
