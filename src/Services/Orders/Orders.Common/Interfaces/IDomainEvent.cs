using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Common.Interfaces
{
    public interface IDomainEvent:INotification
    {
    }
}
