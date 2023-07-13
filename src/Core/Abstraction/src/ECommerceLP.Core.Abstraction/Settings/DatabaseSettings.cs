using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Settings
{
    public sealed class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
