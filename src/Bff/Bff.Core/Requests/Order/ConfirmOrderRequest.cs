using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Core.Requests.Order
{
    public  class ConfirmOrderRequest
    {
        public Guid OrderId { get; set; }
    }
}
