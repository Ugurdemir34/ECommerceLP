using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Exception
{
    public class CustomBusinessException:CustomException
    {
        public CustomBusinessException(string message)
                  : base(message)
        {
        }

        public CustomBusinessException(string message, params object[] args)
            : base(message)
        {
            this.Args = args?.ToList();
        }

        public CustomBusinessException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public CustomBusinessException(int errorCode, string message)
            : base(errorCode, message)
        {
        }

        public CustomBusinessException(int errorCode, string message, params object[] args)
            : base(errorCode, message)
        {
            this.Args = args?.ToList();
        }

        public List<object> Args { get; set; } = new List<object>();
    }
}
