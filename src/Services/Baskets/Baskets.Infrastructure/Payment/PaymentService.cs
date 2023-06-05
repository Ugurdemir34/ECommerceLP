using Baskets.Application.CQRS.Baskets.Commands.BuyBasket;
using Baskets.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Infrastructure.Payment
{
    public class PaymentService : IPaymentService
    {
        public bool PaymentSuccess(BuyBusketCommand command)
        {
            return default;
        }
    }
}
