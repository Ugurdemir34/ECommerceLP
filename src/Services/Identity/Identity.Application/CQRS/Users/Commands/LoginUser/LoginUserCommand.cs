using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.Dtos;
using Identity.Common.Requests;

namespace Identity.Application.CQRS.Users.Commands.LoginUser
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
