using AutoMapper;
using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using Orders.Application.CQRS.Orders.Extensions;
using Orders.Common.Dtos;
using Orders.Domain.Aggregate.OrderAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Orders.Application.CQRS.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderRepo = _unitOfWork.GetCommandRepository<Order>();
            var mapped = command.CreateOrder();
            await orderRepo.AddAsync(mapped);
            _unitOfWork.SaveChanges();
            return mapped.Map();

        }
    }
}
