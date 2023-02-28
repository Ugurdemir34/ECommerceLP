using BCrypt.Net;
using Identity.Application.Common.Abstracts;
using Identity.Application.CQRS.Commands;
using Identity.Application.Options;
using Identity.Common.Dtos;
using Identity.Domain.Entities;
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
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public Task<LoginDto> GenerateTokenAsync(User user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim("username", user.UserName.ToString()),
               new Claim("userId", user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = "http://dev.chandu.com",
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = jwtHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new LoginDto
            {
                IsSuccess = true,
                Token = jwtHandler.WriteToken(token)
            });
        }

        public string HashPassword(string password)
        {
            var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashedPass = sha.ComputeHash(bytes);
            var aaaa= Convert.ToBase64String(hashedPass);
            return aaaa;

        }
        #region OLD
        //public bool CheckPasswordAsync(string password, string passwordHash)
        //{
        //    var aaaa = BCrypt.Net.BCrypt.Verify(<)
        //    if (aaaa == bbbb)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public Task<LoginDto> GenerateTokenAsync(User user)
        //{
        //    var jwtHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        //    var claims = new List<Claim>
        //    {
        //       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //       new Claim("username", user.UserName.ToString()),
        //       new Claim("userId", user.Id.ToString())
        //    };

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Audience = "http://dev.chandu.com",
        //        Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
        //        SigningCredentials =
        //        new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };


        //    var token = jwtHandler.CreateToken(tokenDescriptor);

        //    return Task.FromResult(new LoginDto
        //    {
        //        IsSuccess = true,
        //        Token = jwtHandler.WriteToken(token)
        //    });
        //}

        //public string HashPassword(string password)
        //{
        //    return BCrypt.Net.BCrypt.HashPassword(password);
        //} 
        #endregion
    }
}
