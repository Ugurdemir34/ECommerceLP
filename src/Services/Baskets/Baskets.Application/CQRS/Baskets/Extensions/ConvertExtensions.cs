using Baskets.Application.CQRS.Baskets.Commands.CreateBasket;
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
            var basket = new Basket(command.UserId);
            return basket;
        }
        //public static OrderDto Map(this Order order)
        //{
        //    return new OrderDto
        //    {
        //        CanceledDate = order.CanceledDate,
        //        ConfirmDate = order.ConfirmDate,
        //        CreatedBy = order.CreatedBy,
        //        ModifiedBy = order.ModifiedBy,
        //        ModifiedDate = order.ModifiedDate,
        //        CreatedDate = order.CreatedDate,
        //        Expiry = order.Expiry,
        //        Id = order.Id,
        //        Number = order.Number,
        //        OrderDate = order.OrderDate,
        //        OrderItems = order.OrderItems.MapListDto(),
        //        OrderStatus = (int)order.Status,
        //        TotalPrice = order.TotalPrice,
        //        UserId = order.UserId,
        //        Address = order.Address.Map()
        //    };
        //}
    }
}
