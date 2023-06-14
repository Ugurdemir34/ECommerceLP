using ECommerceLP.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Security
{
    public static class SecurityHashing
    {
        public static string ComputeHash(HashAlgorithmType hashType, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ApplicationException($"Input cannot be null or empty.");
            }

            var hashProvider = HashProvider.CreateHash(hashType);

            return hashProvider.ComputeHash(input.EncodeString()).ToHexValue();
        }
        public static bool ValidateHash(HashAlgorithmType hashType, string hashedValue, string dataToValidate)
        {
            if (string.IsNullOrEmpty(hashedValue))
            {
                throw new ApplicationException($"Input cannot be null or empty.");
            }

            return Equals(ComputeHash(hashType, dataToValidate), hashedValue);
        }
        private static byte[] EncodeString(this string source)
        {
            return Encoding.UTF8.GetBytes(source);
        }
    }
}
