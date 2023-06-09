using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.CQRS.Abstraction.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.CQRS.Abstraction
{
    public interface IProcessor
    {
        Task<T> ProcessAsync<T>(ICommand<T> request, CancellationToken cancellationToken);
        Task<T> ProcessAsync<T>(IQuery<T> request, CancellationToken cancellationToken);
    }
}
