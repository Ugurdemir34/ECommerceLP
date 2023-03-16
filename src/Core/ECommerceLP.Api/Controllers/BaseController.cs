using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController:ControllerBase
    {
    }
}
