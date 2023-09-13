using Baskets.Common.Dtos;
using Bff.Core.Requests.Baskets;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Baskets.Command.AddBasketItem
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
