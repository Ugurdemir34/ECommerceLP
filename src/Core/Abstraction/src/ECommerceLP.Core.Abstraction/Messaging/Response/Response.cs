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
        public Response(T body, bool isSuccess,string error)
        {
            this.Body = body;
            this.Errors = error;
        }
        public Response(T body, bool isSuccess, string error,string exceptionType)
        {
            this.Body = body;
            this.Errors = error;
            this.ExceptionType = exceptionType;
        }
        public T Body { get; set; }
        public string Errors { get; set; }
        public string ExceptionType { get; set; }
        public static Response<TBody> Success<TBody>(TBody body)
        {
            return new Response<TBody>(body, true);
        }

        public static Response<TBody> Fail<TBody>(TBody body, int responseCode)
        {
            return new Response<TBody>(body, false, responseCode);
        }
        public static Response<TBody> Fail<TBody>(TBody body, string error)
        {
            return new Response<TBody>(body, false, error);
        }
        public static Response<TBody> Fail<TBody>(TBody body, string error, string exceptionType)
        {
            return new Response<TBody>(body, false, error,exceptionType);
        }
    }
}
