using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Extensions
{
    public static class ByteExtensions
    {
        public static string ToHexValue(this byte[] input)
        {
            var hex = new StringBuilder(input.Length * 2);
            foreach (var b in input)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}
