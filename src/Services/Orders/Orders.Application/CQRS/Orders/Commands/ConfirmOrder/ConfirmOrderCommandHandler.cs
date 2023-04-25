using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using MediatR;
using Orders.Domain.Aggregate.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.ConfirmOrder
{
    public class ConfirmOrderCommandHandler : ICommandHandler<ConfirmOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ConfirmOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            var Qrepo = _unitOfWork.GetQueryRepository<Order>();
            var confirmedOrder = await Qrepo.GetAsync(o => o.Id == request.OrderId);
            confirmedOrder.ApproveOrder();

            var Crepo = _unitOfWork.GetCommandRepository<Order>();
            await Crepo.UpdateAsync(confirmedOrder);
            _unitOfWork.SaveChanges();

            return true;

        }
    }
}
