using Baskets.Common.Dtos;
using Bff.Application.Baskets.Command.AddBasketItem;
using Bff.Application.Baskets.Command.BuyBasket;
using Bff.Application.Baskets.Command.CreateBasket;
using Bff.Application.Baskets.Command.DeleteBasketItem;
using Bff.Application.Identity.Command.CreateUser;
using Bff.Application.Identity.Command.LoginUser;
using Bff.Core.Requests.Baskets;
using Bff.Core.Requests.Identity;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.BFF.Controllers;
using ECommerceLP.Core.CQRS.Abstraction;
using Identity.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bff.Api.Controllers.Baskets
{
    public class BasketItemController : BaseApiBff
    {
        #region Variables
        private readonly IProcessor _processor;

        #endregion
        #region Constructor
        public BasketItemController(IProcessor processor)
        {
            _processor = processor;
        }
        #endregion
        #region Create
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<BasketItemDto>> Create(AddBasketItemRequest request, CancellationToken cancellationToken)
        {
            var command = new AddBasketItemCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        [HttpPost]
        [Route("Delete")]
        [Authorize]
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
