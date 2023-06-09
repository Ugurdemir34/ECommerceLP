using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.Abstraction.Extensions
{
    public static class StringExtensions
    {
        public static string GetModelName(this string fullName)
        {
            var splitArray = fullName?.Split('.').ToList();
            if (splitArray?.Count > 3) return splitArray[3];
            return string.Empty;
        }
    }
}
