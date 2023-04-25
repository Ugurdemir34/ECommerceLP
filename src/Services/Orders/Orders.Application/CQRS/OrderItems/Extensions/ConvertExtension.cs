using Orders.Common.Dtos;
using Orders.Domain.Aggregate.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.OrderItems.Extensions
{
    public static class ConvertExtension
    {
        public static OrderItem Map(this OrderItemDto item)
        {
            return new OrderItem(item.OrderId, item.ProductId, item.Amount, item.Price);
        }
        public static List<OrderItem> MapList(this List<OrderItemDto> item)
        {
            var list = new List<OrderItem>();
            foreach (var itemDto in item) 
            {
                list.Add(new OrderItem(itemDto.OrderId, itemDto.ProductId, itemDto.Amount, itemDto.Price));
            }
            return list;
        }
        public static List<OrderItemDto> MapListDto(this List<OrderItem> item)
        {
            var list = new List<OrderItemDto>();
            foreach (var itemDto in item)
            {
                list.Add(new OrderItemDto 
                { 
                    Id=itemDto.Id,
                    Amount=itemDto.Amount,
                    CreatedDate=itemDto.CreatedDate,
                    ModifiedDate=itemDto.ModifiedDate,
                    OrderId=itemDto.OrderId,
                    Price=itemDto.Price,
                    ProductId = itemDto.ProductId
                 });
            }
            return list;
        }
    }
}
