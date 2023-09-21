using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Exception
{
    public class CustomException : System.Exception
    {
        public int ErrorCode { get; set; }

        public CustomException()
        {
        }

        public CustomException(string message)
            : base(message)
        {
        }

        public CustomException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public CustomException(int errorCode, string message)
            : this(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
