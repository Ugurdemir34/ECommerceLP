using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(int statusCode,string Message) : base(statusCode,true, Message)
        {

        }
    }
}
