using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Aggregate.OrderAggregates
{
    public enum OrderStatus
    {
        Paid,
        Shipped,
        Canceled
    }
}
