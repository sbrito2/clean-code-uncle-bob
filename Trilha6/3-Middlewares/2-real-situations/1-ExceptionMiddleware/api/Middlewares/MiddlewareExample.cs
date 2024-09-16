using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context,  RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (InvalidOperationException ex)
            {
                await HandleBadRequestResultAsync(context, ex);
            }
            // catch (NotFoundException ex)
            // {
            //     await HandleNotFoundResultAsync(context, ex);
            // }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error: {ex}");
                await HandleExceptionAsync(context);
            }
        }

        private Task HandleBadRequestResultAsync(HttpContext context, InvalidOperationException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.BadRequest, "Middleware: Bad Request ");
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            return WriteResponseAsync(context, HttpStatusCode.InternalServerError, "Middleware: Internal Server Error ");
        }

        private Task WriteResponseAsync(HttpContext context, HttpStatusCode statusCode, object response)
        {
             string result;
            context.Response.StatusCode = (int) statusCode;
            result = JsonConvert.SerializeObject(new { error = response });
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }

        public static IServiceCollection AddExceptionMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<ExceptionMiddleware>();
        }
    }
}
