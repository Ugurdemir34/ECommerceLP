using Baskets.Common.Dtos;
using Baskets.Common.Requests.Basket;
using Baskets.Common.Requests.BasketItem;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Abstraction.RemoteCall;
using ECommerceLP.Core.RemoteCall.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Common.RemoteCall
{
    public interface IBasketRemoteCallService : IRemoteCallService
    {
        [CustomPost("/api/basket/create")]
        Task<Response<BasketDto>> BasketCreate(CreateBasketRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/basket/checkout")]
        Task<Response<BasketDto>> BasketCheckout(BuyBusketRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/basketitems/add")]
        Task<Response<BasketItemDto>> BasketItemsAdd(AddBasketItemRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/basketitems/delete")]
        Task<Response<bool>> BasketItemDelete(DeleteBasketItemRequest request, CancellationToken cancellationToken);
    }
}
