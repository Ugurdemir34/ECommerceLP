using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Settings
{
    public class RedisConfiguration
    {
        public string Url { get; set; }
        public string Port { get; set; }
        public string Host { get; set; }
        public int Expiration { get; set; }
    }
}
