﻿using Baskets.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Core.Requests.Baskets
{
    public class DeleteBasketItemRequest
    {
        public string BasketItemId { get; set; }
        public string BasketId { get; set; }
    }
}
