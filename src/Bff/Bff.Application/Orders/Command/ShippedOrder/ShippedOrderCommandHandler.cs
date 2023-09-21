using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.RemoteCall;
using Microsoft.AspNetCore.Http;
using Orders.Common.Constants;
using Orders.Common.Requests.Order;

namespace Bff.Application.Orders.Command.ShippedOrder
{
    public class ShippedOrderCommandHandler : ICommandHandler<ShippedOrderCommand, bool>
    {
        private readonly IOrderRemoteCallService _orderRemoteCallService;

        public ShippedOrderCommandHandler(IOrderRemoteCallService orderRemoteCallService)
        {
            _orderRemoteCallService = orderRemoteCallService;
        }

        public async Task<bool> Handle(ShippedOrderCommand request, CancellationToken cancellationToken)
        {
            return (await _orderRemoteCallService.Shipped(new ShippedOrderRequest() { OrderId = request.OrderId }, cancellationToken)).Body;
        }
    }
}
