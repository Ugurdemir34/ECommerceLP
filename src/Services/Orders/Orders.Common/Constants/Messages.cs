using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Common.Constants
{
    public class Messages
    {
        public static string SetConfirmSuccess(string value)
        {
            return $"Your order dated {value} confirmed !";
        }
        public static string SetShippedSuccess()
        {
            return $"Your order has been delivered on {DateTime.Now}";
        }
    }
}
