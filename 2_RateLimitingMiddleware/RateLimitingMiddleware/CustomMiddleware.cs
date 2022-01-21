using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RateLimitingMiddelware
{
    public enum StrategyType
    {
        IpAddress
    }

    public class RequestDetails
    {
        public DateTime? LastUpdate { get; set; }
        public int Count { get; set; }
    }

    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        static readonly ConcurrentDictionary<string, RequestDetails> ApiCallsInMemory =
            new ConcurrentDictionary<string, RequestDetails>(StringComparer.OrdinalIgnoreCase);

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var endpoint = httpContext.GetEndpoint();
            var controllerActionDescriptor = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>();

            if (controllerActionDescriptor is null)
            {
                await _next(httpContext);
                return;
            }


            string key = GetCurrentClientKey(httpContext);

            RequestDetails previousApiCall = GetPreviousApiCallByKey(key);
            if (previousApiCall != null)
            {

                if (DateTime.Now < Convert.ToDateTime(previousApiCall.LastUpdate).AddSeconds(10) && previousApiCall.Count > 10)
                {
                    UpdateApiCallFor(key, previousApiCall.Count + 1);
                    httpContext.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    return;
                }
                if (DateTime.Now > Convert.ToDateTime(previousApiCall.LastUpdate).AddSeconds(10))
                {
                    UpdateApiCallFor(key, 1);
                }
                else { UpdateApiCallFor(key, previousApiCall.Count + 1); }

            }
            else
            {
                UpdateApiCallFor(key, 1);
            }



            await _next(httpContext);
        }

        private void UpdateApiCallFor(string key, int count)
        {
            RequestDetails dtls = new RequestDetails();
            dtls.LastUpdate = DateTime.Now;
            dtls.Count = count;
            ApiCallsInMemory.TryRemove(key, out _);
            ApiCallsInMemory.TryAdd(key, dtls);
        }

        private RequestDetails GetPreviousApiCallByKey(string key)
        {
            ApiCallsInMemory.TryGetValue(key, out RequestDetails value);
            return value;
        }


        private static string GetCurrentClientKey(HttpContext context)
        {
            return context.Connection.RemoteIpAddress.ToString();
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
