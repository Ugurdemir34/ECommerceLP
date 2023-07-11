using ECommerceLP.Core.Abstraction.Exception;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using ECommerceLP.Core.Security;
using ECommerceLP.Core.UnitOfWork.Abstraction;
using Identity.Application.Common.Abstracts;
using Identity.Common.Constants;
using Identity.Common.Dtos;
using Identity.Persistence.Context;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ITokenHelper _authentication;
        private readonly IUnitOfWork<UserContext> _unitOfWork;
        private readonly ILogger<LoginUserCommandHandler> _logger;
        public LoginUserCommandHandler(ITokenHelper authentication, IUnitOfWork<UserContext> unitOfWork, ILogger<LoginUserCommandHandler> logger)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetQueryRepository<ModelUser>();
            var user = await repo.GetAsync(u => u.UserName == request.UserName);
            if (user == null)
            {
                //_logger.LogInformation(Messages.UserNameOrPasswordInCorrect, true, request);
                throw new CustomBusinessException(Messages.UserNameOrPasswordInCorrect);
            }
            if (!SecurityHashing.ValidateHash(HashAlgorithmType.Sha256, user.PasswordHash, request.Password))
            {
                //_logger.Log(LogLevel.Error, Messages.UserNameOrPasswordInCorrect, true, request);
                throw new CustomBusinessException(Messages.UserNameOrPasswordInCorrect);
            }
            return _authentication.GenerateToken(user.UserName, user.Id, user.UserType);

        }
    }
}
