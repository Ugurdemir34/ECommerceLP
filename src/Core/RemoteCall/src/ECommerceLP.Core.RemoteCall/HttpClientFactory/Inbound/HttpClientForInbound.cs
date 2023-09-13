using ECommerceLP.Core.RemoteCall.Settings;
using ECommerceLP.Core.Serialization.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.RemoteCall.HttpClientFactory.Inbound
{
    internal class HttpClientForInbound:HttpClient
    {
        public HttpClientForInbound
            (IHttpContextAccessor httpContextAccessor,
            RemoteCallServiceSetting serviceSettings,
            IJSONSerializer serializer):base(new HttpClientHandlerForInbound(httpContextAccessor,serviceSettings,serializer))
        {
            
        }
    }
}
