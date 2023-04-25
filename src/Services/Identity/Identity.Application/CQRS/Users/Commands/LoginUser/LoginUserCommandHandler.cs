using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Common.Security;
using ECommerceLP.Infrastructure.UnitOfWork;
using Identity.Application.Common.Abstracts;
using Identity.Common.Constants;
using Identity.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using ModelUser = Identity.Domain.Aggregate.UserAggregate.Entities.User;
namespace Identity.Application.CQRS.Users.Commands.LoginUser
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
            var repo = _unitOfWork.GetQueryRepository<ModelUser>();
            var user = await repo.GetAsync(u => u.UserName == request.UserName);
            if (!SecurityHashing.ValidateHash(HashAlgorithmType.Sha256, user.PasswordHash, request.Password))
            {
                throw new Exception(Messages.UserNameOrPasswordInCorrect);
            }
            return _authentication.GenerateToken(user.UserName, user.Id);

        }
    }
}
