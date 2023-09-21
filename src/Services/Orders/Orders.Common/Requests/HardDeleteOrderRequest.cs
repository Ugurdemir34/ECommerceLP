using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Common.Requests.Order
{
    public class HardDeleteOrderRequest
    {
        public Guid OrderId { get; set; }
    }
}
