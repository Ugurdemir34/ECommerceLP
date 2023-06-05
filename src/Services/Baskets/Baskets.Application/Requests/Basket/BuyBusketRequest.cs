using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Requests.Basket
{
    public class BuyBusketRequest
    {
        public Guid UserId { get; set; }
        public string FullAddress { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
        public string CardSecurityNumber { get; set; }
        public string CardHolderName { get; set; }
    }
}
