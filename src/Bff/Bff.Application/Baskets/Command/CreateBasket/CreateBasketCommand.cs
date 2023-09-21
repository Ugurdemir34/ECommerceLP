using Baskets.Common.Dtos;
using Bff.Core.Requests.Baskets;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Baskets.Command.CreateBasket
{
    public class CreateBasketCommand : ICommand<BasketDto>
    {
        public Guid UserId { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public bool IsOrdered { get; set; } = false;

        public CreateBasketCommand(CreateBasketRequest request)
        {
            BasketItems = request.BasketItems;
        }
    }
}
