using Baskets.Application.CQRS.BasketItems.Extensions;
using Baskets.Common.Constants;
using Baskets.Common.Dtos;
using Baskets.Domain.Aggregate.BasketAggregate;
using Baskets.Persistence.Contexts;
using DnsClient.Internal;
using ECommerceLP.Core.Abstraction.Exception;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.Mongo.Abstractions;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskets.Application.CQRS.BasketItems.Commands.CreateBasketItem
{
    public class AddBasketItemCommandHandler : ICommandHandler<AddBasketItemCommand, BasketItemDto>
    {
        private readonly IMongoRepositoryFactory<BasketContext> _context;
        private readonly ILogger<AddBasketItemCommandHandler> _logger;
        public AddBasketItemCommandHandler(IMongoRepositoryFactory<BasketContext> context, ILogger<AddBasketItemCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<BasketItemDto> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketRepo = _context.GetRepository<Basket>();
            var existingsBasket = await basketRepo.AnyAsync(b => b.Id == request.BasketId);
            if (!existingsBasket)
            {
                throw new CustomBusinessException(Messages.BasketNotFound);
            }
            var basketItemRepo = _context.GetRepository<BasketItem>();
            var addedBasketItem = request.CreateBasketItem();
            await basketRepo.PushAsync(u=>u.Push(x=>x.BasketItems,addedBasketItem),x=>x.Id==request.BasketId);
            return addedBasketItem.Map();
            //var basketRepository = _unitOfWork.GetCommandRepository<ModelBasket>();
        }
    }
}
