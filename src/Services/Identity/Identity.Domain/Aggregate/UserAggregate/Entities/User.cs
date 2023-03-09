using ECommerceLP.Domain.Entities;
using Identity.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Aggregate.UserAggregate.Entities
{
    public class User : BaseEntity,IAggregateRoot
    {
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
