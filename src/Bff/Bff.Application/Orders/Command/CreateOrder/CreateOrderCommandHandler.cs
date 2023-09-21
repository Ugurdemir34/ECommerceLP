using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.RemoteCall;
using Orders.Common.Dtos;
using Orders.Common.Requests.Order;
namespace Bff.Application.Orders.Command.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IOrderRemoteCallService _orderRemoteCallService;

        public CreateOrderCommandHandler(IOrderRemoteCallService orderRemoteCallService)
        {
            _orderRemoteCallService = orderRemoteCallService;
        }
        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return (await _orderRemoteCallService.Create(new CreateOrderRequest() { Address=request.Address,Number=request.Number,OrderItems=request.OrderItems,Status=request.Status,UserId=request.UserId }, cancellationToken)).Body;
        }
    }
}
