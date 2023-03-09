using ECommerceLP.Common.Results.Concrete;
using Identity.API.Infrastructure;
using Identity.Application.Contracts.User;
using Identity.Application.CQRS.User.Commands.LoginUser;
using Identity.Common.Constants;
using Identity.Common.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiController
    {
        public AuthController(ISender sender) : base(sender)
        {

        }
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DataResult<LoginDto>> Login(LoginRequest login, CancellationToken cancellationToken)
        {
            var command = new LoginUserCommand(login);
            var result = new SuccessDataResult<LoginDto>((int)HttpStatusCode.OK, await Sender.Send(command, cancellationToken), Messages.LoginSuccess);
            return result;
        }
    }
}
