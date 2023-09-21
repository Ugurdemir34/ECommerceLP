using Bff.Core.Requests.Order;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Orders.Command.DeleteOrder
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
