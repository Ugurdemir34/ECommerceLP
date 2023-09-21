using Baskets.Common.Constants;
using Baskets.Domain.Aggregate.BasketAggregate;
using Baskets.Application.CQRS.Baskets.Extensions;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.Abstraction.Exception;
using Microsoft.Extensions.Logging;
using ECommerceLP.Core.Mongo.Abstractions;
using Baskets.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Baskets.Common.Dtos;

namespace Baskets.Application.CQRS.Baskets.Commands.CreateBasket
{
    public class CreateBasketCommandHandler : ICommandHandler<CreateBasketCommand, BasketDto>
    {
        private readonly IMongoRepositoryFactory<BasketContext> _context;
        private readonly ILogger<CreateBasketCommandHandler> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateBasketCommandHandler(ILogger<CreateBasketCommandHandler> logger, IMongoRepositoryFactory<BasketContext> context, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _context = context;
            _httpContextAccessor = accessor;
        }

        public async Task<BasketDto> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext.User.FindFirst("userId");
            if (user == null)
            {
                throw new CustomBusinessException(Messages.YouDontHavePermission);

            }

            var basketRepo = _context.GetRepository<Basket>();
            var basket = await basketRepo.AnyAsync(b => b.UserId == Guid.Parse(user.Value));
            if (basket)
            {
                throw new CustomBusinessException(Messages.BasketAlreadyExists);
            }
            var addedBasket = request.CreateBasket();
            addedBasket.UserId = Guid.Parse(user.Value);//metodla yaz
            addedBasket.BasketItems.ForEach(bi => { bi.BasketId = addedBasket.Id; });
            await basketRepo.AddAsync(addedBasket);
            return addedBasket.Map();
        }
    }
}
