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
    [Route("api/[controller]")]
    [ApiController]
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
            //var result = new SuccessDataResult<LoginDto>((int)HttpStatusCode.OK, await Sender.Send(command, cancellationToken), Messages.LoginSuccess);
            //return result;
        }
        //[HttpPost("Test")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<DataResult<CreateUserDTO>> Test(RegisterRequest login, CancellationToken cancellationToken)
        //{
        //    var command = new CreateUserCommand(login);
        //    var result = new SuccessDataResult<CreateUserDTO>((int)HttpStatusCode.OK, await Sender.Send(command, cancellationToken), Messages.LoginSuccess);
        //    return result;
        //}
    }
}
