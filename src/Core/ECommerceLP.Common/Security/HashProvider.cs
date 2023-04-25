using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Common.Security
{
    internal static class HashProvider
    {
        public static HashAlgorithm CreateHash(HashAlgorithmType hashType)
        {
            return hashType switch
            {
                HashAlgorithmType.Sha1 => new SHA1Managed(),
                HashAlgorithmType.Sha256 => new SHA256Managed(),
                HashAlgorithmType.Sha384 => new SHA384Managed(),
                HashAlgorithmType.Sha512 => new SHA512Managed(),
                _ => new SHA256Managed(),
            };
        }
    }
}
