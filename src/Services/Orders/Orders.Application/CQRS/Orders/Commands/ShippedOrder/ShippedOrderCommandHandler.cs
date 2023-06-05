using ECommerceLP.Application.Interfaces.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using EventBus.Base.Abstraction;
using Microsoft.AspNetCore.Http;
using Orders.Application.CQRS.Orders.Commands.ConfirmOrder;
using Orders.Application.CQRS.Orders.Extensions;
using Orders.Common.Constants;
using Orders.Domain.Aggregate.OrderAggregates;
using Orders.Domain.Aggregate.OrderAggregates.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.ShippedOrder
{
    public class ShippedOrderCommandHandler : ICommandHandler<ShippedOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShippedOrderCommandHandler(IUnitOfWork unitOfWork, IEventBus eventBus, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Handle(ShippedOrderCommand request, CancellationToken cancellationToken)
        {
            //var userType = _httpContextAccessor.HttpContext.User.FindFirst("userType").Value;
            //if (userType != UserType.Admin.ToString())
            //{
            //    throw new Exception(Messages.YouDontHavePermission);
            //}
            var Qrepo = _unitOfWork.GetQueryRepository<Order>();
            var QIrepo = _unitOfWork.GetQueryRepository<OrderItem>();
            var shippedOrder = await Qrepo.GetAsync(o => o.Id == request.OrderId);
            shippedOrder.SetOrderList(await QIrepo.ListAsync(oi => oi.OrderId == shippedOrder.Id));
            shippedOrder.ShipStatus();

            var Crepo = _unitOfWork.GetCommandRepository<Order>();
            await Crepo.UpdateAsync(shippedOrder);
            _unitOfWork.SaveChanges();
            var message = shippedOrder.Map();
            var @event = new OrderShippedIntegrationEvent
            {
                TotalPrice = message.TotalPrice,
                FullAddress = $"{message.Address.Province}/{message.Address.Line}/{message.Address.Street} {message.Address.ZipCode}",
                UserId = message.UserId,
                Message = Messages.SetShippedSuccess(),
            };
            _eventBus.Publish(@event);
            return true;

        }
    }
}
