using Baskets.Application.Requests.Basket;
using Baskets.Application.Requests.BasketItem;
using Baskets.Common.Dtos;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
