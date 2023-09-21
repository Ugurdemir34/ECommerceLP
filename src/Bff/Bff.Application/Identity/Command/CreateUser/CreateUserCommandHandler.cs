using ECommerceLP.Core.CQRS.Abstraction.Command;
using Identity.Common.Dtos;
using Identity.Common.RemoteCall;
using Identity.Common.Requests;

namespace Bff.Application.Identity.Command.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserDTO>
    {
        private readonly IAuthRemoteCallService _callService;

        public CreateUserCommandHandler(IAuthRemoteCallService callService)
        {
            _callService = callService;
        }

        public async Task<CreateUserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return (await _callService.Register(new RegisterRequest() { EMail=request.EMail,FirstName=request.FirstName,LastName=request.LastName,Password=request.Password,PhoneNumber=request.PhoneNumber,UserName=request.UserName,UserType=request.UserType }, cancellationToken)).Body;
        }
    }
}
