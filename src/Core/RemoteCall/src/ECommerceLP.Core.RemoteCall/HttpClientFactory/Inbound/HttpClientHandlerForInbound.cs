using ECommerceLP.Core.RemoteCall.Settings;
using ECommerceLP.Core.Serialization.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.RemoteCall.HttpClientFactory.Inbound
{
    internal class HttpClientHandlerForInbound:HttpClientHandler
    {
        private readonly IJSONSerializer _JsonSerializer;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RemoteCallServiceSetting _RemoteCallServiceSetting;
        public HttpClientHandlerForInbound(
           IHttpContextAccessor httpContextAccessor,
           RemoteCallServiceSetting RemoteCallServiceSetting,
           IJSONSerializer JsonSerializer)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._RemoteCallServiceSetting = RemoteCallServiceSetting;
            this._JsonSerializer = JsonSerializer;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            this._httpContextAccessor.HttpContext.Items["IsInternalRemoteCall"] = true;
            this.CustomizeHttpHeader(request);

            var watch = Stopwatch.StartNew();
            var result = await this.Invoke(request, cancellationToken);
            watch.Stop();
            return result;

        }
        private void CustomizeHttpHeader(HttpRequestMessage request)
        {
            if (request.Content != null)
            {
                if (!string.IsNullOrWhiteSpace(this._RemoteCallServiceSetting.ContentType))
                {
                    request.Content.Headers.Remove("Content-Type");
                    request.Content.Headers.TryAddWithoutValidation("Content-Type",
                        this._RemoteCallServiceSetting.ContentType);
                }

            }      

            //if (!string.IsNullOrEmpty(nexusInfoAccessor.ClientInfo?.AuthToken))
            //{
            //    var token = nexusInfoAccessor.ClientInfo?.AuthToken;
            //    request.Headers.Add("Authorization", $"Bearer {token}");
            //}

        }
        private async Task<HttpResponseMessage> Invoke(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (this._RemoteCallServiceSetting.RetrySettings.IsEnabled)
            {
                var connRetryPolicy = Policy
                    .Handle<HttpRequestException>(exception =>
                        exception.StatusCode == null ||
                        this._RemoteCallServiceSetting.RetrySettings.HttpStatusCodes.Contains(exception.StatusCode
                            .Value))
                    .WaitAndRetryAsync(
                        this._RemoteCallServiceSetting.RetrySettings.ConnectionRetryTimes,
                        i => this._RemoteCallServiceSetting.RetrySettings.ConnectionBetweenExceptionWait,
                        (exception, timeSpan, retryCount, context) =>
                        {
                           
                        });

                return await connRetryPolicy.ExecuteAsync(async (x) => await base.SendAsync(request, x),
                    cancellationToken);
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }
        }

       
    }
}
