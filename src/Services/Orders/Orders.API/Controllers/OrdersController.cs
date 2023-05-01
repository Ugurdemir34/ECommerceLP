using ECommerceLP.Api.Controllers;
using ECommerceLP.Application.CQRS.Abstract;
using ECommerceLP.Common.Messaging.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.CQRS.Orders.Commands.ConfirmOrder;
using Orders.Application.CQRS.Orders.Commands.CreateOrder;
using Orders.Application.CQRS.Orders.Commands.DeleteOrder;
using Orders.Application.CQRS.Orders.Commands.ShippedOrder;
using Orders.Application.Requests.Order;
using Orders.Common.Dtos;

namespace Orders.API.Controllers
{
    public class OrdersController : BaseApi
    {
        private readonly IProcessor _processor;

        public OrdersController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<OrderDto>> Create(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateOrderCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        //[HttpDelete("HardDelete")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<Response<bool>> HardDelete(HardDeleteOrderRequest request, CancellationToken cancellationToken)
        //{
        //    var command = new HardDeleteOrderCommand(request);
        //    var result = await _processor.ProcessAsync(command, cancellationToken);
        //    return this.ProduceResponse(result);
        //}
        [HttpDelete("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<bool>> Delete(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteOrderCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }

        [HttpPost("Confirm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<bool>> Confirm(ConfirmOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new ConfirmOrderCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        [HttpPost("Shipped")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<bool>> Shipped(ShippedOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new ShippedOrderCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
