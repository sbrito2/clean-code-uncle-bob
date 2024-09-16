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

            if (!context.Response.HasStarted)
            {
                string result;

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                result = JsonConvert.SerializeObject(new { error = "Passou no middleware!!" });
                // _logger.LogError(ex, CreateErrorMessage(context));              

                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(result);
            }
            else
            {
                return context.Response.WriteAsync(string.Empty);
            }

            // await httpContext.Response.WriteAsync("Chamou nosso middleware (antes)");
            // await _next(httpContext);
            // await httpContext.Response.WriteAsync("Chamou nosso middleware (depois)");
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
