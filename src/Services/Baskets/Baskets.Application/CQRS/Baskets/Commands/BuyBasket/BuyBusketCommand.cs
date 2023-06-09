using Baskets.Application.Requests.Basket;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Baskets.Application.CQRS.Baskets.Commands.BuyBasket
{
    public class BuyBusketCommand : ICommand<bool>
    {
        public Guid UserId { get; set; }
        public string FullAddress { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
        public string CardSecurityNumber { get; set; }
        public string CardHolderName { get; set; }
        public BuyBusketCommand(BuyBusketRequest request)
        {
            UserId = request.UserId;
            FullAddress = request.FullAddress;
            CardTypeId = request.CardTypeId;
            CardNumber = request.CardNumber;
            CardSecurityNumber = request.CardSecurityNumber;
            CardHolderName = request.CardHolderName;
            CardSecurityNumber = request.CardSecurityNumber;
        }
    }
}
