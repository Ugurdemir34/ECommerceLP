using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.RemoteCall;
using Orders.Common.Requests.Order;

namespace Bff.Application.Orders.Command.ConfirmOrder
{
    public class ConfirmOrderCommandHandler : ICommandHandler<ConfirmOrderCommand, bool>
    {
        private readonly IOrderRemoteCallService _orderRemoteCallService;

        public ConfirmOrderCommandHandler(IOrderRemoteCallService orderRemoteCallService)
        {
            _orderRemoteCallService = orderRemoteCallService;
        }

        public async Task<bool> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            return (await _orderRemoteCallService.Confirm(new ConfirmOrderRequest() {OrderId=request.OrderId }, cancellationToken)).Body;
        }
    }
}
