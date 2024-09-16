
using System;
using System.Linq;
using System.Threading.Tasks;
using API.Infraestructure.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace API.Presentation.API.Middlewares
{
    public class GlobalMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalMiddleware> _logger;

        public GlobalMiddleware(ILogger<GlobalMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var db = (DomainContext)context.RequestServices.GetService(typeof(DomainContext));
            if (context.Request.HttpContext.User.Identity.IsAuthenticated)
            {
                int profileId = context.Request.HttpContext.User.Claims.Where(x => x.Type == "ProfileId").Select(x => int.Parse(x.Value)).First();
                if (profileId != 0)
                {
                    int userId = context.Request.HttpContext.User.Claims.Where(x => x.Type == "UserId").Select(x => int.Parse(x.Value)).First();
                    db.SetUserId(userId);
                }
            }

            await next(context);

            if (db.ChangeTracker.HasChanges())
            {
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }

    public static class GlobalMiddlewareExtensions
    {
        public static IServiceCollection AddGlobalMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<GlobalMiddleware>();
        }

        public static void UseGlobalMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalMiddleware>();
        }
    }
}
