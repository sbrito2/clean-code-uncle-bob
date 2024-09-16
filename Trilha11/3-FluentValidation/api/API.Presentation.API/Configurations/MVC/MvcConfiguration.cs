using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiContrib.Core.Formatter.Csv;
using Microsoft.Net.Http.Headers;
using MediaTypeHeaderValue = Microsoft.Net.Http.Headers.MediaTypeHeaderValue;
using FluentValidation.AspNetCore;
// using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace API.Presentation.API.Extensions.Authentication
{
    public static class MvcConfiguration
    {
        public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {  
            services.AddMvc(config =>
			{
                // config.Filters.Add(new ValidateJwtTokenFilter());
                config.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));
				config.OutputFormatters.Add(new CsvOutputFormatter(new CsvFormatterOptions { CsvDelimiter = ";", Encoding = Encoding.UTF8 }));
                config.EnableEndpointRouting = false;
			}).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
        }
    }
}