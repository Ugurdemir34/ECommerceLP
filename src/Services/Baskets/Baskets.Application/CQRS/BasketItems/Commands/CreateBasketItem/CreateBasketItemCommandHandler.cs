using ECommerceLP.Application.Interfaces.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.CQRS.BasketItems.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandHandler : ICommandHandler<CreateBasketItemCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBasketItemCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            return default;
            //var basketRepository = _unitOfWork.GetCommandRepository<ModelBasket>();
        }
    }
}
