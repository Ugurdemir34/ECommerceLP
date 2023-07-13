using Baskets.Application.CQRS.Baskets.Commands.BuyBasket;
using Baskets.Application.CQRS.Baskets.Commands.CreateBasket;
using Baskets.Application.Requests.Basket;
using Baskets.Common.Dtos;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.Controllers;
using ECommerceLP.Core.CQRS.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Baskets.API.Controllers
{
    public class BasketsController : BaseApi
    {
        #region Variables
        private readonly IProcessor _processor;

        #endregion
        #region Constructor
        public BasketsController(IProcessor processor)
        {
            _processor = processor;
        }
        #endregion
        #region Create
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<BasketDto>> Create(CreateBasketRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateBasketCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        [HttpPost]
        [Route("Checkout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<BasketDto>> Checkout(BuyBusketRequest request, CancellationToken cancellationToken)
        {
            var command = new BuyBasketCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion
    }
}
