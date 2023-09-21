using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Common.Requests.Order
{
    public class DeleteOrderRequest
    {

        public Guid OrderId { get; set; }
    }
}
