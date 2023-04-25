using AutoMapper;
using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using Identity.Application.CQRS.Users.Extensions;
using Identity.Common.Dtos;
using Identity.Domain.Aggregate.UserAggregate.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Identity.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateUserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetCommandRepository<User>();
            var added = request.CreateUser();
            await repo.AddAsync(added);
            _unitOfWork.SaveChanges();
            return added.Map();
        }
    }
}
