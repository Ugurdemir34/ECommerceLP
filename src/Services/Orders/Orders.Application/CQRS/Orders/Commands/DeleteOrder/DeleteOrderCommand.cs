using ECommerceLP.Application.Interfaces.Abstract;
using Orders.Application.Requests.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : ICommand<bool>
    {
        public Guid OrderId { get; set; }
        public DeleteOrderCommand(DeleteOrderRequest request)
        {
            OrderId = request.OrderId;
        }
    }
}
