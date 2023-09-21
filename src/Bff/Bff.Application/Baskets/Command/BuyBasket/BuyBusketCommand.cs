using Baskets.Common.Dtos;
using Bff.Core.Requests.Baskets;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Bff.Application.Baskets.Command.BuyBasket
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
