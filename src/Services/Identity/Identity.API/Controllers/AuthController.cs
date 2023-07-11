using Identity.Application.Requests.User;
using Identity.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using Identity.Application.CQRS.Users.Commands.LoginUser;
using Identity.Application.CQRS.Users.Commands.CreateUser;
using ECommerceLP.Core.Api.Controllers;
using ECommerceLP.Core.CQRS.Abstraction;
using ECommerceLP.Core.Abstraction.Messaging.Response;

namespace Identity.API.Controllers
{
    public class AuthController : BaseApi
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
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<LoginDto>> Login(LoginRequest login, CancellationToken cancellationToken)
        {
            var command = new LoginUserCommand(login);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion

        #region Register
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<CreateUserDTO>> Register(RegisterRequest login, CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(login);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        #endregion
    }
}
