using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using Orders.Domain.Aggregate.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
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
