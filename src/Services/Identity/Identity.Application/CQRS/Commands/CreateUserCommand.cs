using ECommerceLP.Application.Messaging.Abstract;
using Identity.Application.Contracts.User;
using Identity.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Identity.Application.CQRS.Commands
{
    public sealed class CreateUserCommand : ICommand<CreateUserDTO>
    {
        public RegisterRequest _reqisterRequest;
        public CreateUserCommand(RegisterRequest registerRequest)
        {
            _reqisterRequest = registerRequest;
        }
    }
}
