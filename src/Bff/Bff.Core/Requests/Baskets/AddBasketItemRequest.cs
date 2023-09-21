using Baskets.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Core.Requests.Baskets
{
    public class AddBasketItemRequest
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public string BasketId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
