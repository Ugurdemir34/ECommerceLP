using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.RemoteCall.Settings
{
    public sealed class RemoteCallServiceSettings : Dictionary<string, RemoteCallServiceSetting>,
        IOptions<RemoteCallServiceSettings>
    {
        RemoteCallServiceSettings IOptions<RemoteCallServiceSettings>.Value => this;
    }
    public sealed class RemoteCallServiceSetting
    {
        public string Endpoint { get; set; }

        public string NamingStrategy { get; set; }

        public string ContentType { get; set; }

        public RetrySettings RetrySettings { get; set; }

        public RemoteCallServiceSetting()
        {
            RetrySettings = new RetrySettings();
        }
       
    }
    public sealed class RetrySettings
    {
        public int ConnectionRetryTimes { get; set; }

        public TimeSpan ConnectionBetweenExceptionWait { get; set; }

        public List<HttpStatusCode> HttpStatusCodes { get; set; }

        public bool IsEnabled { get; set; }

        public RetrySettings()
        {
            this.ConnectionRetryTimes = 3;
            this.ConnectionBetweenExceptionWait = TimeSpan.FromSeconds(1);
            this.IsEnabled = true;
            this.HttpStatusCodes =
                new() { HttpStatusCode.GatewayTimeout, HttpStatusCode.InternalServerError };
        }
    }
}
