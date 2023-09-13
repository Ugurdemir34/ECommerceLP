using Bff.Core.Requests.Identity;
using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.Dtos;
using Identity.Common.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bff.Application.Identity.Command.CreateUser
{
    public sealed class CreateUserCommand : ICommand<CreateUserDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }

        public CreateUserCommand(RegisterRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            EMail = request.EMail;
            UserName = request.UserName;
            Password = request.Password;
            PhoneNumber = request.PhoneNumber;
            UserType = request.UserType;
        }
    }
}
