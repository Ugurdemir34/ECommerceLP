using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using EventBus.Base.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Http;
using Orders.Application.CQRS.Orders.Extensions;
using Orders.Common.Constants;
using Orders.Domain.Aggregate.OrderAggregates;
using Orders.Domain.Aggregate.OrderAggregates.IntegrationEvents.Events;
using Orders.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.ConfirmOrder
{
    public class ConfirmOrderCommandHandler : ICommandHandler<ConfirmOrderCommand, bool>
    {
        private readonly IUnitOfWork<OrderContext> _unitOfWork;
        private readonly IEventBus _eventBus;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ConfirmOrderCommandHandler(IEventBus eventBus, IHttpContextAccessor httpContextAccessor, IUnitOfWork<OrderContext> unitOfWork)
        {
            _eventBus = eventBus;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            //var userType = _httpContextAccessor.HttpContext.User.FindFirst("userType").Value;
            //if (userType != UserType.Admin.ToString())
            //{
            //    throw new Exception(Messages.YouDontHavePermission);
            //}
            var Qrepo = _unitOfWork.GetQueryRepository<Order>();
            var QIrepo = _unitOfWork.GetQueryRepository<OrderItem>();
            var confirmedOrder = await Qrepo.GetAsync(o => o.Id == request.OrderId);
            confirmedOrder.SetOrderList(await QIrepo.ListAsync(oi => oi.OrderId == confirmedOrder.Id));
            confirmedOrder.ApproveOrder();

            var Crepo = _unitOfWork.GetCommandRepository<Order>();
            await Crepo.UpdateAsync(confirmedOrder);
            _unitOfWork.SaveChanges();
            var message = confirmedOrder.Map();
            var @event = new OrderConfirmIntegrationEvent
            {
                TotalPrice = message.TotalPrice,
                FullAddress = $"{message.Address.Province}/{message.Address.Line}/{message.Address.Street} {message.Address.ZipCode}",
                UserId = message.UserId,
                Message = Messages.SetConfirmSuccess(message.OrderDate.ToLongDateString()),
            };
            _eventBus.Publish(@event);

            return true;

        }
    }
}
