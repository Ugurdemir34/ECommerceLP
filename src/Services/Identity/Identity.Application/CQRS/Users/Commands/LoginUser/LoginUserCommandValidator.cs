using FluentValidation;
using Identity.Application.CQRS.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CQRS.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
