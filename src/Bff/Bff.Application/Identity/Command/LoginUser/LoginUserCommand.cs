using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bff.Application.Identity.Command.LoginUser
{
    public class LoginUserCommand : ICommand<LoginDto>
    {
        public LoginUserCommand(
            string userName,
            string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }
}
