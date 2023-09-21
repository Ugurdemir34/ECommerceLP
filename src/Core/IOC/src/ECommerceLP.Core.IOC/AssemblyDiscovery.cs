using ECommerceLP.Core.Abstraction.Library;
using ECommerceLP.Core.IOC.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.IOC
{
    public class AssemblyDiscovery : SingletonBase<AssemblyDiscovery>, IAssemblyDiscovery
    {
        public Assembly ApiAssembly { get; }

        public IEnumerable<Assembly> AbstractionAssemblies { get; }

        public IEnumerable<Assembly> ApplicationAssemblies { get; }

        public IEnumerable<Assembly> CoreAssemblies { get; }

        public IEnumerable<Assembly> DomainAssemblies { get; }
        public IEnumerable<Assembly> CommonAssemblies { get; }

        public IEnumerable<Assembly> RepositoryAssemblies { get; }
        private AssemblyDiscovery()
        {
            this.ApiAssembly = Assembly.GetEntryAssembly();

            var path = Path.GetDirectoryName(this.ApiAssembly.Location);
            var moduleAssemblies = Directory
                .GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly)
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                .ToList();

            this.AbstractionAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Abstraction"));
            this.ApplicationAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Application"));
            this.CoreAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Core"));
            this.DomainAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Domain"));
            this.RepositoryAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Persistence"));
            this.CommonAssemblies = moduleAssemblies.Where(x => x.FullName.Contains("Common"));
        }
    }
}
