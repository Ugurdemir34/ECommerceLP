using ECommerceLP.Application.Interfaces.Abstract;
using Orders.Application.Requests.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.ShippedOrder
{
    public class ShippedOrderCommand : ICommand<bool>
    {
        public Guid OrderId { get; set; }
        public ShippedOrderCommand(ShippedOrderRequest request)
        {
            OrderId = request.OrderId;
        }
    }
}
