using Identity.Application.CQRS.Users.Commands.CreateUser;
using Identity.Common.Dtos;
using Identity.Domain.Aggregate.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Users.Extensions
{
    public static class ConvertExtensions
    {
        public static User CreateUser(this CreateUserCommand command)
        {
            var user = new User(command.FirstName, command.LastName, command.EMail, command.UserName, command.Password, command.PhoneNumber, command.UserType);
            return user;
        }
        public static CreateUserDTO Map(this User user)
        {
            return new CreateUserDTO
            {
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ModifiedDate = user.ModifiedDate,
                EMail = user.EMail,
                UserName = user.UserName,
                UserType = user.UserType,
            };
        }
    }
}
