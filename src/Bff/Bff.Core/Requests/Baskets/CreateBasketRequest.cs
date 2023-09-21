using Baskets.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Core.Requests.Baskets
{
    public class CreateBasketRequest
    {
        public List<BasketItemDto> BasketItems { get; set; }
    }
}
