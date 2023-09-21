using Baskets.Common.RemoteCall;
using Baskets.Common.Requests.BasketItem;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Baskets.Command.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler : ICommandHandler<DeleteBasketItemCommand, bool>
    {
        private readonly IBasketRemoteCallService _basketRemoteCallService;

        public DeleteBasketItemCommandHandler(IBasketRemoteCallService basketRemoteCallService)
        {
            _basketRemoteCallService = basketRemoteCallService;
        }

        public async Task<bool> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            return (await _basketRemoteCallService.BasketItemDelete(new DeleteBasketItemRequest() { BasketId = request.BasketId, BasketItemId = request.BasketItemId }, cancellationToken)).Body;

        }
    }
}
