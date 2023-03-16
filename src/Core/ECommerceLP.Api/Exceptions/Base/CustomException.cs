using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Api.Exceptions.Base
{
    public class CustomException:Exception
    {
        public int ErrorCode { get; set; }
        public CustomException()
        {
            

        }
        public CustomException(string message):base(message)
        {
            
        }
        public CustomException(string message,Exception inEx):base(message,inEx)
        {
            
        }
        public CustomException(int errorCode, string message)
            : this(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
