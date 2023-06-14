using AutoMapper;
using DotNetCore.CAP;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using Microsoft.AspNetCore.Http;
using Orders.Application.CQRS.Orders.Extensions;
using Orders.Common.Dtos;
using Orders.Domain.Aggregate.OrderAggregates;
using Orders.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace Orders.Application.CQRS.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUnitOfWork<OrderContext> _unitOfWork;
        private IMapper _mapper;
        public CreateOrderCommandHandler(IUnitOfWork<OrderContext> unitOfWork, IMapper mapper, IHttpContextAccessor accessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accessor = accessor;
        }
        public async Task<OrderDto> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            command.CreatedBy = userId;
            command.ModifiedBy = userId;
            var orderRepo = _unitOfWork.GetCommandRepository<Order>();
            var mapped = command.CreateOrder();
            await orderRepo.AddAsync(mapped);
            _unitOfWork.SaveChanges();
            return mapped.Map();
        }
    }
}
