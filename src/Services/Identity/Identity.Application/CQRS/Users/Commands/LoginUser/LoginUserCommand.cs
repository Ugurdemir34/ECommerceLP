using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Application.Requests.User;
using Identity.Common.Dtos;

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
