using ECommerceLP.Common.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Results.Concrete
{
    public class Result : IResult
    {
        public Result(int statusCode,bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }

        public bool IsSuccess { get; }

        public string Message { get; }
        public int StatusCode { get; }
    }
}
