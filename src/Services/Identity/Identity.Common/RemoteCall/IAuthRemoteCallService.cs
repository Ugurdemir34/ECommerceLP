using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Abstraction.RemoteCall;
using ECommerceLP.Core.RemoteCall.Attributes;
using Identity.Common.Dtos;
using Identity.Common.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Common.RemoteCall
{
    public interface IAuthRemoteCallService : IRemoteCallService
    {
        [CustomPost("/api/auth/login")]
        Task<Response<LoginDto>> Login(LoginRequest request, CancellationToken cancellationToken);
        [CustomPost("/api/auth/register")]
        Task<Response<CreateUserDTO>> Register(RegisterRequest request, CancellationToken cancellationToken);
    }
}
