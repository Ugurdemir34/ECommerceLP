using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Messaging.Response
{
    public class Response<T>
    {
        public Response(T body, bool isSuccess, int code = 0)
        {
            this.Body = body;
        }
        public T Body { get; set; }

        public static Response<TBody> Success<TBody>(TBody body)
        {
            return new Response<TBody>(body, true);
        }

        public static Response<TBody> Fail<TBody>(TBody body, int responseCode)
        {
            return new Response<TBody>(body, false, responseCode);
        }
    }
}
