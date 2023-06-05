﻿using Baskets.Application.CQRS.Baskets.Commands.CreateBasket;
using Baskets.Application.Requests.Basket;
using ECommerceLP.Api.Controllers;
using ECommerceLP.Application.CQRS.Abstract;
using ECommerceLP.Common.Messaging.Response;
using Microsoft.AspNetCore.Mvc;

namespace Baskets.API.Controllers
{
    public class BasketsController : BaseApi
    {
        private readonly IProcessor _processor;

        public BasketsController(IProcessor processor)
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
