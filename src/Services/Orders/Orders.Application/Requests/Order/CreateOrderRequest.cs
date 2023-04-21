using Orders.Common.Dtos;
using Orders.Domain.Aggregate.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.Requests.Order
{
    public class CreateOrderRequest
    {
        public Guid UserId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
        public OrderStatus Status { get; set; }
        public long Number { get; set; }
    }
}
