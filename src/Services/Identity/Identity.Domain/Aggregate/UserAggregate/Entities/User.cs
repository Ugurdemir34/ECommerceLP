using ECommerceLP.Common.Security;
using ECommerceLP.Domain.Common.Interfaces;
using ECommerceLP.Domain.Entities;
using Identity.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Aggregate.UserAggregate.Entities
{
    public class User : BaseEntity, IAggregateRoot
    {
        public User()
        {

        }
        public User(string firstName, string lastName,
                    string email, string username,
                    string passwordHash, string phoneNumber,
                    UserType usertype, string refreshToken=null)
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = email;
            UserName = username;
            PasswordHash = SecurityHashing.ComputeHash(HashAlgorithmType.Sha256,passwordHash);
            PhoneNumber = phoneNumber;
            RefreshToken = refreshToken;
            RefreshTokenExpiry = default(DateTime);
            UserType = usertype;

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EMail { get; private set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string PhoneNumber { get; private set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
        public UserType UserType { get; private set; }
    }
}
