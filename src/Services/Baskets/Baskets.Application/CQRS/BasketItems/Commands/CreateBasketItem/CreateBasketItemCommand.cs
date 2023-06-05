using Baskets.Application.Requests.Basket;
using Baskets.Application.Requests.BasketItem;
using ECommerceLP.Application.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.CQRS.BasketItems.Commands.CreateBasketItem
{
    public class CreateBasketItemCommand : ICommand<bool>
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountedPrice { get; set; }

        public CreateBasketItemCommand(CreateBasketItemRequest request)
        {
            ProductId = request.ProductId;
            UserId = request.UserId;
            ProductName = request.ProductName;
            Price = request.Price;
        }
    }
}
