using Microsoft.Extensions.Logging;

namespace api.Middlewares.Logging
{
    public class CustomLoggerProviderConfiguration 
    {
        public LogLevel LogLevel {get; set; } = LogLevel.Warning;
        public int EventId { get; set; } = 0;
    }
}