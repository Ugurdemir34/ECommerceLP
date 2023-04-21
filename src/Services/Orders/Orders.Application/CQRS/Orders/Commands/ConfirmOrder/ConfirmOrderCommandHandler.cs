using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using MediatR;
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

        Task<bool> IRequestHandler<ConfirmOrderCommand, bool>.Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
