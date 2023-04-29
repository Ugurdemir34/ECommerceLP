using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Mail.Models
{
    public class EMailAddress
    {
        public string Address { get; }
        public string DisplayName { get; }
        public EMailAddress(string emailAddress, string displayName)
        {
            this.Address = emailAddress;
            this.DisplayName = displayName;
        }
    }
}
