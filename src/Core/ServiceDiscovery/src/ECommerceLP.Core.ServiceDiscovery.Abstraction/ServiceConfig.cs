﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.ServiceDiscovery.Abstraction
{
    public class ServiceConfig
    {
        public Uri ServiceDiscoveryAddress { get; set; }
        public Uri ServiceAddress { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
    }
}
