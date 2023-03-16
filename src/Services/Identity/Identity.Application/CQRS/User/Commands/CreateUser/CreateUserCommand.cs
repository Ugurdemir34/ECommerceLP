﻿using ECommerceLP.Application.Messaging.Abstract;
using Identity.Application.Requests.User;
using Identity.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Identity.Application.CQRS.User.Commands.CreateUser
{
    public sealed class CreateUserCommand : ICommand<CreateUserDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Guid UserTypeId { get; set; }

        public CreateUserCommand(RegisterRequest registerRequest)
        {
            FirstName = registerRequest.FirstName;
            LastName = registerRequest.LastName;
            EMail = registerRequest.EMail;
            UserName = registerRequest.UserName;
            Password = registerRequest.Password;
            PhoneNumber = registerRequest.PhoneNumber;
            UserTypeId = registerRequest.UserTypeId;
        }
    }
}
