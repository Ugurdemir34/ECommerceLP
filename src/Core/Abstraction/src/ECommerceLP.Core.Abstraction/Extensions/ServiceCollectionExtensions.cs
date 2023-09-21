using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ToScan(this IServiceCollection services,
                  Action<ITypeSourceSelector> action)
        {
            return services.Scan(action);
        }
    }
}
