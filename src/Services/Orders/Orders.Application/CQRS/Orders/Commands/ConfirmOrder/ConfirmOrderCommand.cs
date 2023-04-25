﻿using ECommerceLP.Application.Messaging.Abstract;
using Orders.Application.Requests.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.ConfirmOrder
{
    public class ConfirmOrderCommand : ICommand<bool>
    {
        public Guid OrderId { get; set; }
        public ConfirmOrderCommand(ConfirmOrderRequest request)
        {
            OrderId = request.OrderId;
        }
    }
}