using Baskets.Application.CQRS.BasketItems.Extensions;
using Baskets.Common.Constants;
using Baskets.Domain.Aggregate.BasketAggregate;
using Baskets.Persistence.Contexts;
using ECommerceLP.Core.Abstraction.Exception;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.Mongo.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Baskets.Application.CQRS.BasketItems.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler : ICommandHandler<DeleteBasketItemCommand, bool>
    {
        private readonly IMongoRepositoryFactory<BasketContext> _context;
        private readonly ILogger<DeleteBasketItemCommandHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeleteBasketItemCommandHandler(IMongoRepositoryFactory<BasketContext> context, ILogger<DeleteBasketItemCommandHandler> logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst("userId").Value);
            var basketRepo = _context.GetRepository<Basket>();
            var existingsBasket = await basketRepo.AnyAsync(b => b.Id == request.BasketId && b.UserId == userId);
            if (!existingsBasket)
            {
                throw new CustomBusinessException(Messages.BasketNotFound);
            }
            var basketItemRepo = _context.GetRepository<BasketItem>();
            var deleted = request.CreateBasketItem();
            await basketRepo.PushAsync(u => u.PullFilter(x => x.BasketItems, bi => bi.Id == request.BasketItemId), x => x.Id == request.BasketId);
            return true;
            //var basketRepository = _unitOfWork.GetCommandRepository<ModelBasket>();
        }
    }
}
