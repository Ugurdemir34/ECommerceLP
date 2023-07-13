using Baskets.Application.CQRS.Baskets.Commands.BuyBasket;
using Baskets.Application.CQRS.Baskets.Commands.CreateBasket;
using Baskets.Common.Dtos;
using Baskets.Domain.Aggregate.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.CQRS.Baskets.Extensions
{
    public static class ConvertExtensions
    {
        public static Basket CreateBasket(this CreateBasketCommand command)
        {
            var basket = new Basket()
            {
                BasketItems = command.BasketItems.CreateList(),
                IsOrdered = command.IsOrdered
            };
            return basket;
        }
        //public static Basket CreateBasket(this BuyBasketCommand command, Guid userId)
        //{
        //    var basket = new Basket()
        //    {
        //        BasketItems = command.Ba
        //        UserId = userId,

        //    };
        //    return basket;
        //}
        public static List<BasketItem> CreateList(this List<BasketItemDto> item)
        {
            var list = new List<BasketItem>();
            foreach (var itemDto in item)
            {
                list.Add(new BasketItem(itemDto.BasketId, itemDto.ProductId, itemDto.Amount, itemDto.Price));
            }
            return list;
        }
        public static BasketDto Map(this Basket basket)
        {
            return new BasketDto
            {
                Id = basket.Id,
                IsOrdered = basket.IsOrdered,
                BasketItems = basket.BasketItems.MapList(),
            };
        }
        public static List<BasketItemDto> MapList(this List<BasketItem> item)
        {
            var list = new List<BasketItemDto>();
            foreach (var itemDto in item)
            {
                list.Add(new BasketItemDto
                {
                    ProductId = itemDto.ProductId,
                    Amount = itemDto.Amount,
                    Price = itemDto.Price
                });
            }
            return list;
        }
    }
}
