using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareExample
    {
        private readonly RequestDelegate _next;

        public MiddlewareExample(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            return context.Response.WriteAsync("\nHello World From 2st Middleware!");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExampleExtensions
    {
        public static IApplicationBuilder UseMiddlewareExample(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareExample>();
        }
    }
}
