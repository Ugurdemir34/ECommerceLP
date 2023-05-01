using AutoMapper;
using DotNetCore.CAP;
using ECommerceLP.Application.Interfaces.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Orders.Application.CQRS.Orders.Extensions;
using Orders.Common.Dtos;
using Orders.Domain.Aggregate.OrderAggregates;
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
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor accessor)
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
