using Bff.Application.Identity.Command.CreateUser;
using Bff.Application.Identity.Command.LoginUser;
using Bff.Core.Requests.Identity;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.BFF.Controllers;
using ECommerceLP.Core.CQRS.Abstraction;
using Identity.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bff.Api.Controllers.Identity
{
    public class AuthController : BaseApiBff
    {
        #region Variables
        private readonly IProcessor _processor;

        #endregion
        #region Constructor
        public AuthController(IProcessor processor)
        {
            _processor = processor;
        } 
        #endregion
        #region Login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<Response<LoginDto>> Login(LoginRequest login, CancellationToken cancellationToken)
        {
            var result = await _processor.ProcessAsync(new LoginUserCommand(login.UserName, login.Password), cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion
        #region Register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<Response<CreateUserDTO>> Register(RegisterRequest register, CancellationToken cancellationToken)
        {
            var result = await _processor.ProcessAsync(new CreateUserCommand(register), cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion
    }
}
