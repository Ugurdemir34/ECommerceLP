using Baskets.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Core.Requests.Baskets
{
    public class BuyBusketRequest
    {
        public string FullAddress { get; set; }
        public string CardNumber { get; set; }
        public string CardSecurityNumber { get; set; }
        public string CardHolderName { get; set; }
        public string BasketId { get; set; }
    }
}
