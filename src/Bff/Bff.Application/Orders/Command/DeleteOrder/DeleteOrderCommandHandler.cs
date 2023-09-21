using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.RemoteCall;
using Orders.Common.Requests.Order;

namespace Bff.Application.Orders.Command.DeleteOrder
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRemoteCallService _orderRemoteCallService;
        public DeleteOrderCommandHandler(IOrderRemoteCallService orderRemoteCallService)
        {
            _orderRemoteCallService = orderRemoteCallService;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            return (await _orderRemoteCallService.Delete(new DeleteOrderRequest() { OrderId = request.OrderId }, cancellationToken)).Body;
        }
    }
}
