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
        private readonly IAuthentication _authentication;
        private readonly IUnitOfWork<UserContext> _unitOfWork;
        private readonly ILogger<LoginUserCommandHandler> _logger;
        public LoginUserCommandHandler(IAuthentication authentication, IUnitOfWork<UserContext> unitOfWork, ILogger<LoginUserCommandHandler> logger)
        {
            _authentication = authentication;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetQueryRepository<ModelUser>();
            var user = await repo.GetAsync(u => u.UserName == request.UserName);
            if(user == null)
            {
                var ex = new CustomBusinessException(Messages.UserNameOrPasswordInCorrect);
                _logger.Log(LogLevel.Warning, ex.Message, true, request);
                throw ex;
            }
            if (!SecurityHashing.ValidateHash(HashAlgorithmType.Sha256, user.PasswordHash, request.Password))
            {
                var ex = new CustomBusinessException(Messages.UserNameOrPasswordInCorrect);
                _logger.Log(LogLevel.Warning, ex.Message, true, request);
                throw ex;
            }
            return _authentication.GenerateToken(user.UserName, user.Id,user.UserType);

        }
    }
}
