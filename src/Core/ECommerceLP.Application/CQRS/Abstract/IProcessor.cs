using ECommerceLP.Application.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECommerceLP.Application.CQRS.Abstract
{
    public interface IProcessor
    {
        Task<T> ProcessAsync<T>(ICommand<T> request, CancellationToken cancellationToken);
        Task<T> ProcessAsync<T>(IQuery<T> request, CancellationToken cancellationToken);
    }
}
