using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Common.Dtos
{
    public class BasketDto
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public float TotalPrice => BasketItems.Sum(b => b.Price);
        public bool IsOrdered { get; set; }
    }
}
