using AutoMapper;
using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using Identity.Application.CQRS.Commands;
using Identity.Common.Dtos;
using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Handlers.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand,CreateUserDTO>
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
            await repo.AddAsync(new User { FirstName = "aaa" });
            _unitOfWork.SaveChanges();
            var added = _mapper.Map<CreateUserDTO>(request._reqisterRequest);
            //var aaa = new CreateUserDTO()
            //{
            //    FirstName = request._reqisterRequest.FirstName
            //};
            return added;
        }
    }
}
