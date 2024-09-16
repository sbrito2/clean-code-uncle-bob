using System.IO;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetCoreApp.v3_0.Tests
{
    [TestClass]
	public class LoggerShould : Swords.Core.Tests.LoggerShould
    {
		protected override IConfigurationRoot GetNetCoreConfiguration()
			=> new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
										 .AddJsonFile("appsettings.json")
										 .Build();

        /// <summary>
        /// Gets the log4net provider options.
        /// </summary>
        /// <returns></returns>
        protected override Log4NetProviderOptions GetLog4NetProviderOptions()
			=> new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
										 .AddJsonFile("appsettings.json")
										 .Build()
										 .GetSection("Log4NetCore")
										 .Get<Log4NetProviderOptions>();
	}
}