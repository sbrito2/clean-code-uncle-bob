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
        private Task HandleBadRequestResultAsync(HttpContext context, BadRequesttException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.BadRequest, false.AsBadRequestResponse(ex.Message));
        }
        
        private Task  NotFoundExceptionResultAsync(HttpContext context, NotFoundException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.BadRequest, false.AsNotFoundResponse(ex.Message));
        }

        private Task HandleConflictResultAsync(HttpContext context, ConflictException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.Conflict, false.AsConflictResponse(ex.Message));
        }

        private Task HandleForbidExceptionResultAsync(HttpContext context, ForbidException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.Conflict, false.AsForbiddenResponse(ex.Message));
        }

        private Task UnprocessableExceptionResultAsync(HttpContext context, UnprocessableException ex)
        {
            return WriteResponseAsync(context, HttpStatusCode.Conflict, false.AsUnprocessableResponse(ex.Message));
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            return WriteResponseAsync(context, HttpStatusCode.InternalServerError, false.AsInternalServerErrorResponse());
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
}