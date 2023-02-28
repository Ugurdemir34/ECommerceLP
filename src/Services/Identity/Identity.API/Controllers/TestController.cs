using Identity.API.Infrastructure;
using Identity.Application.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ApiController
    {
        public TestController(ISender sender):base(sender)
        {

        }
        //[HttpPost("Test")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> Test()
        //{
        //    var aaa = new CreateUserCommand(new Application.Contracts.User.RegisterRequest
        //    {
        //        UserName = "Ugur",
        //        Password = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM="
        //    });
        //    var aa = await Sender.Send(aaa);
        //    return Ok(aa);
        //}
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginUserCommand login)
        {
            var result = await Sender.Send(login);
            return Ok(result);
        }
    }
}
