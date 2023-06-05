using Baskets.Application.Requests.Basket;
using ECommerceLP.Application.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.CQRS.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommand : ICommand<bool>
    {
        public Guid UserId { get; set; }
        public CreateBasketCommand(CreateBasketRequest request)
        {
            UserId = request.UserId;
        }
    }
}
