using Orders.Common.Dtos;
using Orders.Domain.Aggregate.OrderAggregates;

namespace Orders.Common.Requests.Order
{
    public class CreateOrderRequest
    {
        public Guid UserId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
        public OrderStatusDto Status { get; set; }
        public long Number { get; set; }
    }
}
