using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Application.Wrappers.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(string Message) : base(true, Message)
        {

        }
    }
}
