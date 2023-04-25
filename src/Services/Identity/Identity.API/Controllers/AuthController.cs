using Identity.API.Infrastructure;
using Identity.Application.Requests.User;
using Identity.Common.Constants;
using Identity.Common.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ECommerceLP.Common.Results.Concrete;
using ECommerceLP.Api.Controllers;
using ECommerceLP.Application.CQRS.Abstract;
using ECommerceLP.Common.Messaging.Response;
using Identity.Application.CQRS.Users.Commands.LoginUser;
using Identity.Application.CQRS.Users.Commands.CreateUser;

namespace Identity.API.Controllers
{
    public class AuthController : BaseApi
    {
        private readonly IProcessor _processor;

        public AuthController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<LoginDto>> Login(LoginRequest login, CancellationToken cancellationToken)
        {
            var command = new LoginUserCommand(login);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<CreateUserDTO>> Register(RegisterRequest login, CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(login);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
