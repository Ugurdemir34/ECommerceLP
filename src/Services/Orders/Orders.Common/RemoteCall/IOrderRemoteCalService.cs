using ECommerceLP.Core.Abstraction.Collections;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Abstraction.RemoteCall;
using ECommerceLP.Core.RemoteCall.Attributes;
using Orders.Common.Dtos;
using Orders.Common.Requests.Order;

namespace Identity.Common.RemoteCall
{
    public interface IOrderRemoteCallService : IRemoteCallService
    {
        [CustomPost("/api/orders/create")]
        Task<Response<OrderDto>> Create(CreateOrderRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/orders/delete")]
        Task<Response<bool>> Delete(DeleteOrderRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/orders/confirm")]
        Task<Response<bool>> Confirm(ConfirmOrderRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/orders/shipped")]
        Task<Response<bool>> Shipped(ShippedOrderRequest request, CancellationToken cancellationToken);
    }
}
