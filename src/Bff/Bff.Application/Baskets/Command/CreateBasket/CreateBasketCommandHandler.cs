using ECommerceLP.Core.CQRS.Abstraction.Command;
using Baskets.Common.Dtos;
using Baskets.Common.RemoteCall;
using Baskets.Common.Requests.Basket;

namespace Bff.Application.Baskets.Command.CreateBasket
{
    public class CreateBasketCommandHandler : ICommandHandler<CreateBasketCommand, BasketDto>
    {
        private readonly IBasketRemoteCallService _basketRemoteCallService;

        public CreateBasketCommandHandler(IBasketRemoteCallService basketRemoteCallService)
        {
            _basketRemoteCallService = basketRemoteCallService;
        }

        public async Task<BasketDto> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            return (await _basketRemoteCallService.BasketCreate(new CreateBasketRequest() { BasketItems = request.BasketItems }, cancellationToken)).Body;
        }
    }
}
