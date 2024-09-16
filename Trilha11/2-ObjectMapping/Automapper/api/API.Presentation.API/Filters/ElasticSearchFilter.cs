using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using API.Presentation.API.Configurations.Logger.ElasticSearch;
using Microsoft.Extensions.Logging;
using Serilog;

namespace PDG.Presentation.API.Filters
{
    public class ElasticSearchFilter : IAsyncActionFilter
    {
        private readonly ILogger<ElasticSearchFilter> logger;
        public ElasticSearchFilter(ILogger<ElasticSearchFilter> logger)
        {
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var elastic = new ElasticSearchLog();
            elastic.HttpMethod = context.HttpContext.GetEndpoint().DisplayName;
            elastic.Controller = context.Controller.GetType().AssemblyQualifiedName;
            elastic.Action = context.ActionDescriptor.DisplayName;
            elastic.Message = "customized action log for business";
            elastic.UserId  = 1;
            elastic.UserName = "Anne with an e";

            Log.Warning("elasticsearchfilter {@elastic}", elastic);

            await next();
        }
    }
}