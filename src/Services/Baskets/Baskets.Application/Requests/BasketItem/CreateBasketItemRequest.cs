﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Requests.BasketItem
{
    public class CreateBasketItemRequest
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

    }
}
