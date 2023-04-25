using ECommerceLP.Domain.Common.Interfaces;
using ECommerceLP.Domain.Entities;
using Orders.Domain.Aggregate.OrderAggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Aggregate.OrderAggregates
{
    public class Order : BaseDefinitionEntity, IAggregateRoot
    {
        public Order()
        {

        }
        public Order(Guid userId,
                     DateTime orderDate,
                     OrderStatus status,
                     long number,
                     DateTime expiry,
                     Guid createdBy,
                     Guid modifiedBy,
                     DateTime confirmDate,
                     DateTime canceledDate,
                     List<OrderItem> orderItems,
                     Address address
                     )
        {
            UserId = userId;
            OrderDate = orderDate;
            TotalPrice = orderItems.Sum(p => p.Price);
            TotalAmount = orderItems.Sum(a => a.Amount);
            Status = status;
            Number = number;
            Expiry = expiry;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            ConfirmDate = confirmDate;
            CanceledDate = canceledDate;
            OrderItems = orderItems;
            Address = address;
        }
        public Guid UserId { get; private set; }
        public float TotalPrice { get; private set; }
        public int TotalAmount { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public long Number { get; private set; }
        public DateTime Expiry { get; private set; }
        public DateTime ConfirmDate { get; private set; }
        public DateTime CanceledDate { get; private set; }
        public Address Address { get; set; }
        public List<OrderItem> OrderItems { get; private set; }

        public void ApproveOrder()
        {
            this.Status = OrderStatus.Approved;
        }
    }

}
