using ECommerceLP.Api.Controllers;
using ECommerceLP.Common.Messaging.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogs.API.Controllers
{
    public class TestController : BaseApi
    {
        [Authorize]
        [HttpGet("test")]
        public Response<string> Test()
        {
            return this.ProduceResponse("Hello");
        }
    }
}
