using Baskets.Common.Constants;
using Baskets.Domain.Aggregate.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baskets.Application.CQRS.Baskets.Extensions;
using Baskets.Domain.Repositories;
using ECommerceLP.Core.CQRS.Abstraction.Command;

namespace Baskets.Application.CQRS.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommandHandler : ICommandHandler<CreateBasketCommand, bool>
    {
        private readonly IBasketRepository _repository;

        public CreateBasketCommandHandler(IBasketRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = _repository.GetAsync(b => b.UserId == request.UserId, cancellationToken);
            if (basket != null)
            {
                throw new Exception(Messages.BasketAlreadyExists);
            }
            await _repository.AddAsync(request.CreateBasket(), cancellationToken);
            return true;
        }
    }
}
