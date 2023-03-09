using ECommerceLP.Application.Messaging.Abstract;
using ECommerceLP.Common.Results;
using Identity.Application.Contracts.User;
using Identity.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.User.Commands.LoginUser
{
    public class LoginUserCommand : ICommand<LoginDto>
    {
        public LoginUserCommand(LoginRequest request)
        {
            UserName = request.UserName;
            Password = request.Password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
