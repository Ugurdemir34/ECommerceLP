using ECommerceLP.Api.Controllers;
using ECommerceLP.Application.CQRS.Abstract;
using ECommerceLP.Common.Messaging.Response;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.CQRS.Orders.Commands.CreateOrder;
using Orders.Application.Requests.Order;
using Orders.Common.Dtos;

namespace Orders.API.Controllers
{
    public class OrderController : BaseApi
    {
        private readonly IProcessor _processor;

        public OrderController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost("CreateOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<OrderDto>> Login(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateOrderCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
