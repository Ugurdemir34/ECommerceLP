using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.IOC.Abstraction
{
    public interface IAssemblyDiscovery
    {
        public Assembly ApiAssembly { get; }

        public IEnumerable<Assembly> AbstractionAssemblies { get; }

        public IEnumerable<Assembly> ApplicationAssemblies { get; }

        public IEnumerable<Assembly> CoreAssemblies { get; }

        public IEnumerable<Assembly> DomainAssemblies { get; }

        public IEnumerable<Assembly> RepositoryAssemblies { get; }
    }
}
