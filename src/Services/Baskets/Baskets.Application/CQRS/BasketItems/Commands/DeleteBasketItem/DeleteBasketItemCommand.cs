using Baskets.Application.Requests.BasketItem;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Baskets.Application.CQRS.BasketItems.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommand : ICommand<bool>
    {
        public string BasketId { get; set; }
        public string BasketItemId { get; set; }
        public Guid UserId { get; set; }
        public DeleteBasketItemCommand(DeleteBasketItemRequest request)
        {
            BasketId = request.BasketId;
            BasketItemId = request.BasketItemId;
        }
    }
}
