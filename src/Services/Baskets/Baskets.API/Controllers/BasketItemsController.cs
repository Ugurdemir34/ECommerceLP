using Baskets.Application.CQRS.BasketItems.Commands.CreateBasketItem;
using Baskets.Application.CQRS.BasketItems.Commands.DeleteBasketItem;
using Baskets.Application.CQRS.Baskets.Commands.CreateBasket;
using Baskets.Application.Requests.Basket;
using Baskets.Application.Requests.BasketItem;
using Baskets.Common.Dtos;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.Controllers;
using ECommerceLP.Core.CQRS.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Baskets.API.Controllers
{
    public class BasketItemsController : BaseApi
    {
        #region Variables
        private readonly IProcessor _processor;

        #endregion
        #region Constructor
        public BasketItemsController(IProcessor processor)
        {
            _processor = processor;
        }
        #endregion
        #region Add
        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<BasketItemDto>> Add(AddBasketItemRequest request, CancellationToken cancellationToken)
        {
            var command = new AddBasketItemCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion
        #region Delete
        [HttpPost("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<bool>> Delete(DeleteBasketItemRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteBasketItemCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion
    }
}
