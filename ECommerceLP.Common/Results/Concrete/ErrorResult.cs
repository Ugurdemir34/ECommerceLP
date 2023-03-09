using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(int statusCode,string message) : base(statusCode,false, message)
        {
        }
    }
}
