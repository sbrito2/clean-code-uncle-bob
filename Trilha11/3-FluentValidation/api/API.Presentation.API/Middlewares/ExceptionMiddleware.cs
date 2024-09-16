using System;
using System.Net;
using System.Threading.Tasks;
using API.CrossCutting.Utils.Security.Exceptions;
using API.CrossCutting.Utils.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;

namespace API.Presentation.API.Middlewares
{
    public partial class ExceptionMiddleware : IMiddleware
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
            catch (BadRequesttException ex)
            {
                await HandleBadRequestResultAsync(context, ex);
            }
            catch (NotFoundException ex)
            {
                await NotFoundExceptionResultAsync(context, ex);
            }
            catch (ConflictException ex)
            {
                await HandleConflictResultAsync(context, ex);
            }
            catch (ForbidException ex)
            {
                await HandleForbidExceptionResultAsync(context, ex);
            }
            catch (UnprocessableException ex)
            {
                await UnprocessableExceptionResultAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error: {ex}");
                await HandleExceptionAsync(context);
            }
        }
    }

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
