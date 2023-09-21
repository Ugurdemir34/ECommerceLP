using Bff.Core.Requests.Order;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using Orders.Common.Dtos;

namespace Bff.Application.Orders.Command.CreateOrder
{
    public class CreateOrderCommand : ICommand<OrderDto>
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatusDto Status { get; set; }
        public long Number { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime ConfirmDate { get; set; }
        public DateTime CanceledDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
        public CreateOrderCommand(CreateOrderRequest request)
        {
            UserId = request.UserId;
            OrderDate = DateTime.Now;
            Status = request.Status;
            Number = request.Number;
            OrderItems = request.OrderItems;
            Expiry = DateTime.Now.AddDays(10);
            Address = request.Address;
        }
    }
}
