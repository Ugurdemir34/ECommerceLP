using BCrypt.Net;
using ECommerceLP.Application.Settings;
using Identity.Application.Common.Abstracts;
using Identity.Common.Dtos;
using Identity.Common.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
namespace Identity.Application.Common.Concretes
{
    public class AuthenticationService : IAuthentication
    {
        private readonly JwtTokenSettings _jwtSettings;

        public AuthenticationService(JwtTokenSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public LoginDto GenerateToken(string userName, Guid userId, UserType userType)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim("username", userName),
               new Claim("userId", userId.ToString()),
               new Claim("userType", userType.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = "https://www.adesso.com.tr/",
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = jwtHandler.CreateToken(tokenDescriptor);

            //  return Task.FromResult(Result<LoginDto>.Success(200,new LoginDto { Token=jwtHandler.WriteToken(token)}
            //));
            return new LoginDto { Token = jwtHandler.WriteToken(token), RefreshToken = GenerateRefreshToken() };
        }

        private string GenerateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        public string HashPassword(string password)
        {
            var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashedPass = sha.ComputeHash(bytes);
            var aaaa = Convert.ToBase64String(hashedPass);
            return aaaa;

        }
    }
}
