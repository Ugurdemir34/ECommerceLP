using Baskets.Application.Requests.Basket;
using Baskets.Common.Dtos;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Baskets.Application.CQRS.Baskets.Commands.BuyBasket
{
    public class BuyBasketCommand : ICommand<BasketDto>
    {
        public Guid UserId { get; set; }
        public string BasketId { get; set; }
        public string FullAddress { get; set; }
        public string CardNumber { get; set; }
        public string CardSecurityNumber { get; set; }
        public string CardHolderName { get; set; }
        public BuyBasketCommand(BuyBusketRequest request)
        {
            FullAddress = request.FullAddress;
            CardNumber = request.CardNumber;
            CardSecurityNumber = request.CardSecurityNumber;
            CardHolderName = request.CardHolderName;
            BasketId = request.BasketId;
        }
    }
}
