using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace api.Middlewares.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private CustomLoggerProviderConfiguration _loggerConfig;
        readonly ConcurrentDictionary<string, CustomLogger> _loggers = 
            new ConcurrentDictionary<string, CustomLogger>();

        public CustomLoggerProvider(CustomLoggerProviderConfiguration config)
        {
            _loggerConfig = config;
        }

        public ILogger CreateLogger(string category)
        {
            return _loggers.GetOrAdd(category, name => new CustomLogger(name, _loggerConfig));
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}