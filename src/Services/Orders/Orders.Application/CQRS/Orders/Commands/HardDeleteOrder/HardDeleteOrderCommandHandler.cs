using ECommerceLP.Application.Interfaces.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using Orders.Domain.Aggregate.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Application.CQRS.Orders.Commands.DeleteOrder
{
    public class HardDeleteOrderCommandHandler : ICommandHandler<HardDeleteOrderCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public HardDeleteOrderCommandHandler(IUnitOfWork unitOfWork)
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
