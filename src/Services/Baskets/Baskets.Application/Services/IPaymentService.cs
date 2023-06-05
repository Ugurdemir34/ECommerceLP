using Baskets.Application.CQRS.Baskets.Commands.BuyBasket;
using Baskets.Application.Requests.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.Services
{
    public interface IPaymentService
    {
        bool PaymentSuccess(BuyBusketCommand request);
    }
}
