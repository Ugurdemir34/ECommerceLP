using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.Controllers;
using ECommerceLP.Core.CQRS.Abstraction;
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
    //[Authorize]
    public class OrdersController : BaseApi
    {
        private readonly IProcessor _processor;

        public OrdersController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost]
        [Route("Create")]
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
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<bool>> Delete(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteOrderCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }

        [HttpPost]
        [Route("Confirm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<bool>> Confirm(ConfirmOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new ConfirmOrderCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        [HttpPost]
        [Route("Shipped")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<bool>> Shipped(ShippedOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new ShippedOrderCommand(request);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
