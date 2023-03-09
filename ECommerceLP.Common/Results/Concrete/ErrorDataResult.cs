using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(int statusCode,T data, string message) : base(statusCode,data, false, message)
        {
        }

        public ErrorDataResult(int statusCode,T data) : base(statusCode,data, false)
        {
        }

        public ErrorDataResult(int statusCode,string message) : base(statusCode,default, false, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
