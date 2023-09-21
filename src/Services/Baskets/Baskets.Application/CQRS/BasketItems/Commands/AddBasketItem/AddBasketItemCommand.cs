using Baskets.Application.Requests.BasketItem;
using Baskets.Common.Dtos;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Baskets.Application.CQRS.BasketItems.Commands.CreateBasketItem
{
    public class AddBasketItemCommand : ICommand<BasketItemDto>
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public string BasketId { get; set; }

        public AddBasketItemCommand(AddBasketItemRequest request)
        {
            ProductId = request.ProductId;
            Price = request.Price;
            Amount = request.Amount;
            BasketId = request.BasketId;
        }
    }
}
