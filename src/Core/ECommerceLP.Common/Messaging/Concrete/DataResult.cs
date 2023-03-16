using ECommerceLP.Common.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(int statusCode,T data, bool isSuccess, string message)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }
        public DataResult(int statusCode,T data, bool isSuccess)
        {
            Data = data;
            IsSuccess = isSuccess;
            StatusCode = statusCode;
        }
        public DataResult(T data, bool isSuccess)
        {
            Data = data;
            IsSuccess = isSuccess;
        }
        public bool IsSuccess { get; }

        public string Message { get; }
        public T Data { get; }
        public int StatusCode { get; }
    }
}
