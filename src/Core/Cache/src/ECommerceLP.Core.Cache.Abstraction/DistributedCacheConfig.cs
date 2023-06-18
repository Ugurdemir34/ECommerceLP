using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Cache.Abstraction
{
    public class DistributedCacheConfig
    {
        public string Url { get; set; }
        public string Port { get; set; }
        public string Host { get; set; }
    }
}
