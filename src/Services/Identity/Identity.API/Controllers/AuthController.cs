using Identity.API.Infrastructure;
using Identity.Application.Requests.User;
using Identity.Application.CQRS.User.Commands.CreateUser;
using Identity.Application.CQRS.User.Commands.LoginUser;
using Identity.Common.Constants;
using Identity.Common.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ECommerceLP.Common.Results.Concrete;
using ECommerceLP.Api.Controllers;
using ECommerceLP.Application.CQRS.Abstract;
using ECommerceLP.Common.Messaging.Response;

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
        [HttpPost("Test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Response<CreateUserDTO>> Test(RegisterRequest login, CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(login);
            var result = await _processor.ProcessAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
