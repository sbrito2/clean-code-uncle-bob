using System;
using System.Net;
using api.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace api.Middlewares
{
    public static class GlobalExceptionHandleExtension
    {
        public static void UseGlobalExceptionHandlerMiddlewareExtension(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;
                        var problemDetails = context.Request.HttpContext.Request.Path;
                        int code;

                        BaseResponse baseResponse = new BaseResponse();
                        
                        if (exception is BadHttpRequestException badHttpRequestException)
                        {
                            var loggermsg = loggerFactory.CreateLogger("GlobalExceptionHandler: badHttpRequestException");
                            loggermsg.LogError($"Unexpected error: {exceptionHandlerFeature.Error}");
                            loggermsg.LogInformation("Bad Request");

                            baseResponse.BadRequest<BaseResponse>("Exception handle middleware: Bad request,"+
                                "por favor verificar o resquest");
                            code = (int) HttpStatusCode.BadRequest;
                        }
                        else if (exception is DbUpdateException bdException)
                        {
                            var loggermsg = loggerFactory.CreateLogger("GlobalExceptionHandler: DbUpdateException");
                            loggermsg.LogError($"Unexpected error: {exceptionHandlerFeature.Error}");
                            loggermsg.LogInformation("Db update Exeception");

                            baseResponse.DbUpdateError<BaseResponse>();
                            code = (int) HttpStatusCode.InternalServerError;
                        }
                        else 
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler: InternalEror");
                            logger.LogError($"Unexpected error: {exceptionHandlerFeature.Error.Message}");
                            //logger.LogError($"Internal Server Error {DateTime.Now.ToLongTimeString()} {exception.Message}");
                            logger.LogInformation($"Internal Server Error {DateTime.Now.ToLongTimeString()} {exception.Message}");

                            baseResponse.InternalServerError<BaseResponse>("Exception handle middleware: Internal Server Error, " + 
                                "por favor verificar o resquest");
                            code = (int) HttpStatusCode.InternalServerError;
                        }

                        context.Response.StatusCode = code;
                        context.Response.ContentType = "application/problem+json";

                        var json = JsonConvert.SerializeObject(baseResponse);
                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }

        public static IServiceCollection ConfigureProblemDetailsModelState(this IServiceCollection services)
        {
            return services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "Please refer to the errors property for additional details"
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });
        }
    }
}