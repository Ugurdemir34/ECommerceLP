using Baskets.Application.Requests.Basket;
using Baskets.Common.Dtos;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.CQRS.Baskets.Commands.CreateBasket
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
