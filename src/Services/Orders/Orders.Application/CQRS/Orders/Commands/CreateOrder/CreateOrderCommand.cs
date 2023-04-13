using ECommerceLP.Application.Messaging.Abstract;
using Orders.Application.Requests.Order;
using Orders.Common.Dtos;
using Orders.Domain.Aggregate.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : ICommand<OrderDto>
    {
        public Guid UserId { get; set; }
        public float TotalPrice { get; set; }
        public int TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public long Number { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime ConfirmDate { get; set; }
        public DateTime CanceledDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public CreateOrderCommand(CreateOrderRequest request)
        {
            UserId = request.UserId;
            OrderDate = DateTime.Now;
            Status = request.Status;
            Number = request.Number;
            OrderItems = request.OrderItems;
            Expiry = DateTime.Now.AddDays(10);
        }
    }
}
