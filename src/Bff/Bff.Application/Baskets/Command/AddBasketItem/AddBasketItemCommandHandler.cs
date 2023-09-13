using Baskets.Common.Dtos;
using Baskets.Common.RemoteCall;
using Baskets.Common.Requests.BasketItem;
using Bff.Application.Baskets.Command.AddBasketItem;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Baskets.Application.CQRS.BasketItems.Commands.CreateBasketItem
{
    public class AddBasketItemCommandHandler : ICommandHandler<AddBasketItemCommand, BasketItemDto>
    {
        private readonly IBasketRemoteCallService _basketRemoteCallService;
        public AddBasketItemCommandHandler(IBasketRemoteCallService basketRemoteCallService)
        {
            _basketRemoteCallService = basketRemoteCallService;
        }
        public async Task<BasketItemDto> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            return (await _basketRemoteCallService.BasketItemsAdd(new AddBasketItemRequest() { Amount = request.Amount, BasketId = request.BasketId, Price = request.Price, ProductId = request.ProductId }, cancellationToken)).Body;
        }
    }
}
