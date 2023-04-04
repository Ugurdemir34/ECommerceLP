using AutoMapper;
using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using Identity.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelUser = Identity.Domain.Aggregate.UserAggregate.Entities.User;
namespace Identity.Application.CQRS.User.Commands.CreateUser
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
            var repo = _unitOfWork.GetCommandRepository<ModelUser>();
            var added = _mapper.Map<ModelUser>(request);
            await repo.AddAsync(added);
            _unitOfWork.SaveChanges();
            return default;
        }
    }
}
