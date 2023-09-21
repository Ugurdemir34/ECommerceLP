using Baskets.Common.Dtos;
using Baskets.Common.RemoteCall;
using Baskets.Common.Requests.Basket;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Baskets.Command.BuyBasket
{
    public class BuyBasketCommandHandler : ICommandHandler<BuyBasketCommand, BasketDto>
    {
        private readonly IBasketRemoteCallService _basketRemoteCallService;
        public BuyBasketCommandHandler(IBasketRemoteCallService basketRemoteCallService)
        {
            _basketRemoteCallService = basketRemoteCallService;
        }
        public async Task<BasketDto> Handle(BuyBasketCommand request, CancellationToken cancellationToken)
        {
            return (await _basketRemoteCallService.BasketCheckout(new BuyBusketRequest() { BasketId = request.BasketId, CardHolderName = request.CardHolderName, CardNumber = request.CardNumber, CardSecurityNumber = request.CardSecurityNumber, FullAddress = request.FullAddress }, cancellationToken)).Body;
        }
    }
}