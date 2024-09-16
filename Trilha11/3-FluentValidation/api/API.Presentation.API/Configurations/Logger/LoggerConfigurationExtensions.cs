using System;
using Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Elasticsearch;

namespace API.Presentation.API.Configurations.Logger
{
    public static class LoggerConfigurationExtensions
    {
        public static LoggerConfiguration ConfigureSerilog(this LoggerConfiguration config)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return config.ReadFrom.Configuration(configuration)
                // .Enrich.FromLogContext()
                // .ConfigureElasticSearch()
                .ConfigureBusinessElasticSearch();
        }

        public static LoggerConfiguration ConfigureElasticSearch(this LoggerConfiguration config)
        {      
            var elasticSearchUri = "http://localhost:9200";
            var elasticSearchUserName = "elasticsearch";
            var elasticSearchPassword = "2WuoJRttRSyXIYweh-MxEw";

            return config.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchUri))
                {
                    AutoRegisterTemplate = true,
                    TemplateName = "app-log",
                    IndexFormat = "request-log-{0:yyyy.MM.dd}",
                    TypeName = "log",
                    ModifyConnectionSettings = x => x.BasicAuthentication(elasticSearchUserName, elasticSearchPassword),
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                    MinimumLogEventLevel = Serilog.Events.LogEventLevel.Information,
                })
                .Filter.ByIncludingOnly( p => p.MessageTemplate.Text.Contains("HostingRequestStartingLog"));
        }

        public static LoggerConfiguration ConfigureBusinessElasticSearch(this LoggerConfiguration config)
        {      
            var elasticSearchUri = "http://localhost:9200";
            var elasticSearchUserName = "elasticsearch";
            var elasticSearchPassword = "2WuoJRttRSyXIYweh-MxEw";

            return config
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchUri))
                {
                    AutoRegisterTemplate = true,
                    TemplateName = "app-log",
                    IndexFormat = "business-log",
                    TypeName = "log",
                    ModifyConnectionSettings = x => x.BasicAuthentication(elasticSearchUserName, elasticSearchPassword),
                    MinimumLogEventLevel = Serilog.Events.LogEventLevel.Warning,
                
                })
                .Filter.ByIncludingOnly( p => p.MessageTemplate.Text.Contains("elasticsearchfilter"));
        }

        public static LoggerConfiguration ConfigureLogFile(this LoggerConfiguration config, string rollingFilePath, string file)
        {
            if (String.IsNullOrWhiteSpace(rollingFilePath))
            {
                return config;
            }

            return config.WriteTo.File(rollingFilePath + file + ".txt", rollingInterval: RollingInterval.Day, shared: true);
        }
    }
}