using ECommerceLP.Core.CQRS.Abstraction.Command;
using Orders.Application.Requests.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.DeleteOrder
{
    public class HardDeleteOrderCommand : ICommand<bool>
    {
        public Guid OrderId { get; set; }
        public HardDeleteOrderCommand(HardDeleteOrderRequest request)
        {
            OrderId = request.OrderId;
        }
    }
}
