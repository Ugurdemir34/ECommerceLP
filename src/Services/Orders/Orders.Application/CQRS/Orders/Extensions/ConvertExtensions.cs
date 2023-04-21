using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Application.CQRS.Orders.Commands.CreateOrder;
using Orders.Common.Dtos;
using Orders.Domain.Aggregate.OrderAggregates;
using Orders.Application.CQRS.OrderItems.Extensions;
using Orders.Application.CQRS.Addresses.Extensions;
namespace Orders.Application.CQRS.Orders.Extensions
{
    public static class ConvertExtensions
    {
        public static Order CreateOrder(this CreateOrderCommand command)
        {
            var mappedOrderItem = command.OrderItems.MapList();
            var address = command.Address.MapDto();
            var order = new Order(command.UserId, command.OrderDate, command.Status,
                command.Number, command.Expiry, command.CreatedBy, command.ModifiedBy,
                command.ConfirmDate, command.CanceledDate, mappedOrderItem,address);
            return order;
        }
        public static OrderDto Map(this Order order)
        {
            return new OrderDto
            {
                CanceledDate = order.CanceledDate,
                ConfirmDate = order.ConfirmDate,
                CreatedBy = order.CreatedBy,
                ModifiedBy = order.ModifiedBy,
                ModifiedDate = order.ModifiedDate,
                CreatedDate = order.CreatedDate,
                Expiry = order.Expiry,
                Id = order.Id,
                Number = order.Number,
                OrderDate = order.OrderDate,
                OrderItems = order.OrderItems.MapListDto(),
                OrderStatus = (int)order.Status,
                TotalPrice = order.TotalPrice,
                UserId = order.UserId,
            };
        }
    }
}
