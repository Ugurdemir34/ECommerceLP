using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using Orders.Domain.Aggregate.OrderAggregates;
using Orders.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.DeleteOrder
{
    public class HardDeleteOrderCommandHandler : ICommandHandler<HardDeleteOrderCommand, bool>
    {
        private readonly IUnitOfWork<OrderContext> _unitOfWork;

        public HardDeleteOrderCommandHandler(IUnitOfWork<OrderContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(HardDeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderRepo = _unitOfWork.GetCommandRepository<Order>();
            await orderRepo.HardDeleteAsync(request.OrderId);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
