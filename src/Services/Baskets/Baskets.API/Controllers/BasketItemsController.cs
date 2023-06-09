using Baskets.Application.CQRS.Baskets.Commands.CreateBasket;
using Baskets.Application.Requests.Basket;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.Controllers;
using ECommerceLP.Core.CQRS.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Baskets.API.Controllers
{
    public class BasketItemsController:BaseApi
    {
        private readonly IProcessor _processor;

        public BasketItemsController(IProcessor processor)
        {
            _processor = processor;
        }
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<bool>> Create(CreateBasketRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateBasketCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
