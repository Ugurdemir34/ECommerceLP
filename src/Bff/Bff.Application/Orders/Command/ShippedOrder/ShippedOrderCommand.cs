using Bff.Core.Requests.Order;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Orders.Command.ShippedOrder
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
