using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Infrastructure.UnitOfWork;
using Identity.Application.Common.Abstracts;
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
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, LoginDto>
    {
        private readonly IAuthentication _authentication;
        private readonly IUnitOfWork _unitOfWork;

        public LoginUserCommandHandler(IAuthentication authentication, IUnitOfWork unitOfWork)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetQueryRepository<User>();
            var hashedPass= _authentication.HashPassword(request.Password);
            var user =await repo.GetAsync(u=>u.UserName == request.UserName && u.PasswordHash == hashedPass);
            if (user !=null)
            {
                return await _authentication.GenerateTokenAsync(user);
            }
            return new LoginDto
            {
                IsSuccess = false,
                Token = null
            };
        }
    }
}
