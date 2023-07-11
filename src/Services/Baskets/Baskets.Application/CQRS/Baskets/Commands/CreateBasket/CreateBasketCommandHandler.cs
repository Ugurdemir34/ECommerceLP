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
using ECommerceLP.Core.Abstraction.Exception;
using Microsoft.Extensions.Logging;

namespace Baskets.Application.CQRS.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommandHandler : ICommandHandler<CreateBasketCommand, bool>
    {
        private readonly IBasketRepository _repository;
        private readonly ILogger<CreateBasketCommandHandler> _logger;
        public CreateBasketCommandHandler(IBasketRepository repository, ILogger<CreateBasketCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = _repository.GetAsync(b => b.UserId == request.UserId, cancellationToken);
            if (basket != null)
            {
                //_logger.LogInformation(Messages.BasketAlreadyExists, true, request);
                throw new CustomBusinessException(Messages.BasketAlreadyExists);
            }
            await _repository.AddAsync(request.CreateBasket(), cancellationToken);
            return true;
        }
    }
}
