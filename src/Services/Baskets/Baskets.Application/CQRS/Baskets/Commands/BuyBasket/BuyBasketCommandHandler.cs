using Baskets.Application.Services;
using Baskets.Common.Constants;
using Baskets.Domain.Aggregate.BasketAggregate;
using Baskets.Persistence.Contexts;
using ECommerceLP.Core.Abstraction.Exception;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.CQRS.Baskets.Commands.BuyBasket
{
    public class BuyBasketCommandHandler : ICommandHandler<BuyBusketCommand, bool>
    {
        private readonly IPaymentService _paymentService;
        private readonly IUnitOfWork<BasketContext> _unitOfWork;
        public BuyBasketCommandHandler(IPaymentService paymentService, IUnitOfWork<BasketContext> unitOfWork)
        {
            _paymentService = paymentService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(BuyBusketCommand request, CancellationToken cancellationToken)
        {
            if (_paymentService.PaymentSuccess(request))
            {
                var basketQueryRepo = _unitOfWork.GetQueryRepository<Basket>();
                var basket = await basketQueryRepo.GetAsync(b => b.UserId == request.UserId, b => b.BasketItems);
                if (basket != null) { throw new CustomBusinessException(Messages.BasketNotFound); }
                if (basket.BasketItems.Count==0) { throw new CustomBusinessException(Messages.BasketItemsFound); }

                return default;

            }
            return default;
        }
    }
}
