using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.Dtos;
using Identity.Common.RemoteCall;
using Identity.Common.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceLP.Core.Abstraction.Messaging.Response;

namespace Bff.Application.Identity.Command.LoginUser
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, LoginDto>
    {
        private readonly IAuthRemoteCallService _callService;

        public LoginUserCommandHandler(IAuthRemoteCallService callService)
        {
            _callService = callService;
        }

        public async Task<LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return (await _callService.Login(new LoginRequest() { UserName = request.UserName, Password = request.Password }, cancellationToken)).Body;
        }
    }
}
