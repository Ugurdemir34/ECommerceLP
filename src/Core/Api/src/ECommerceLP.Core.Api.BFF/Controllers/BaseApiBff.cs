using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Api.BFF.Controllers
{
    public class BaseApiBff:BaseController
    {
        protected Response<T> ProduceResponse<T>(T body)
        {
            return Response<T>.Success(body);
        }
    }
}
