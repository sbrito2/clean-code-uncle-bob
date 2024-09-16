using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Domain.Notification;
using API.CrossCutting.Utils.Response.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using API.CrossCutting.Utils.Response;

namespace PDG.Presentation.API.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            this.notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)notificationContext.notifications.FirstOrDefault().Code;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(false.AsBadRequestResponse(notificationContext.notifications.FirstOrDefault().Message));
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }
    }
}