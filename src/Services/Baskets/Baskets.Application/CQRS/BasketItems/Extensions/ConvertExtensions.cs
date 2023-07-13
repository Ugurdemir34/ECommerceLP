using Baskets.Application.CQRS.BasketItems.Commands.CreateBasketItem;
using Baskets.Application.CQRS.BasketItems.Commands.DeleteBasketItem;
using Baskets.Application.CQRS.Baskets.Extensions;
using Baskets.Common.Dtos;
using Baskets.Domain.Aggregate.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.CQRS.BasketItems.Extensions
{
    public static class ConvertExtensions
    {
        public static BasketItem CreateBasketItem(this AddBasketItemCommand command)
        {
            return new BasketItem
            {
                Amount = command.Amount,
                Price = command.Price,
                ProductId = command.ProductId,
                BasketId = command.BasketId,                
            };
        }
        public static BasketItem CreateBasketItem(this DeleteBasketItemCommand command)
        {
            return new BasketItem
            {
                BasketId = command.BasketId,
            };
        }
        public static BasketItemDto Map(this BasketItem basket)
        {
            return new BasketItemDto
            {
               BasketId = basket.Id,
               Amount = basket.Amount,
               Price=basket.Price,
               ProductId = basket.ProductId,              
            };
        }
    }
}
