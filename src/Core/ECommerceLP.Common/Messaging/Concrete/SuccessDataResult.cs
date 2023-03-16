using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Results.Concrete
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data):base(data,true)
        {
            
        }
        public SuccessDataResult(int statusCode,T data, string message):base(statusCode,data,true,message)
        {

        }
        public SuccessDataResult(int statusCode,T data) : base(statusCode,data, true)
        {
        }

        public SuccessDataResult(int statusCode,string message) : base(statusCode,default, true, message)
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
