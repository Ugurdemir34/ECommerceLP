using ECommerceLP.Core.Abstraction.Exception;
using ECommerceLP.Core.Abstraction.Messaging.Response;
using ECommerceLP.Core.Api.Exceptions.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace ECommerceLP.Core.Api.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch
            {
                httpContext.Response.ContentType = "application/json";

                var expFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
                var statusCode = expFeature.Error switch
                {
                    ApplicationException => (int)HttpStatusCode.InternalServerError,
                    CustomBusinessException => (int)HttpStatusCode.BadRequest,
                    _ => 500
                };
                httpContext.Response.StatusCode = statusCode;
                var response = Response<NoContentResult>.Fail(statusCode, expFeature.Error.Message, expFeature.Error.GetType().Name);
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
