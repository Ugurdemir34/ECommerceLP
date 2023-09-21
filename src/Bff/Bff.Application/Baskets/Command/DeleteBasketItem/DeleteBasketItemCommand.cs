using Bff.Core.Requests.Baskets;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Baskets.Command.DeleteBasketItem
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
