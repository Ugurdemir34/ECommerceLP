using AutoMapper;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using Identity.Application.CQRS.Users.Extensions;
using Identity.Common.Dtos;
using Identity.Domain.Aggregate.UserAggregate.Entities;
using Identity.Persistence.Context;

namespace Identity.Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserDTO>
    {
        private readonly IUnitOfWork<UserContext> _unitOfWork;
        private IMapper _mapper;
        public CreateUserCommandHandler(IUnitOfWork<UserContext> unitOfWork, IMapper mapper)
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
