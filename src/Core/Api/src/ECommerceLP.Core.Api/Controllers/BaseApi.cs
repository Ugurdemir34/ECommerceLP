using ECommerceLP.Core.Abstraction.Messaging.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Api.Controllers
{
    public class BaseApi : BaseController
    {
        protected Response<T> ProduceResponse<T>(T body)
        {
            return Response<T>.Success(body);
        }
    }
}
