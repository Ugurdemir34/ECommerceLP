using Bff.Core.Requests.Order;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Orders.Command.ConfirmOrder
{
    public class ConfirmOrderCommand : ICommand<bool>
    {
        public Guid OrderId { get; set; }
        public ConfirmOrderCommand(ConfirmOrderRequest request)
        {
            OrderId = request.OrderId;
        }
    }
}
