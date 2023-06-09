using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Api.Exceptions.Base
{
    public class BusinessException : CustomException
    {
        public List<object> Args { get; set; } = new List<object>();
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, params object[] args) : base(message)
        {
            this.Args = args?.ToList();
        }

        public BusinessException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public BusinessException(int errorCode, string message)
            : base(errorCode, message)
        {
        }

        public BusinessException(int errorCode, string message, params object[] args)
            : base(errorCode, message)
        {
            this.Args = args?.ToList();
        }
    }
}
