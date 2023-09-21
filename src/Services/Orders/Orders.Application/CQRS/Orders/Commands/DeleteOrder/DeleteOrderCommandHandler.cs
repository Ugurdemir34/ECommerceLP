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
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, bool>
    {
        private readonly IUnitOfWork<OrderContext> _unitOfWork;
        public DeleteOrderCommandHandler(IUnitOfWork<OrderContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderRepo = _unitOfWork.GetCommandRepository<Order>();
            await orderRepo.DeleteAsync(request.OrderId);
            _unitOfWork.SaveChanges();
            return true;
        }
    }
}
