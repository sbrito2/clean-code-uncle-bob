using API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace API.Presentation.API.Extensions.Authentication
{
    public static class DbContextConfiguration
    {
        public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {  
            services.AddDbContext<DomainContext>(builder =>
			{
				builder.EnableDetailedErrors();
                builder.UseMySQL(configuration.GetConnectionString("default"));
				builder.EnableSensitiveDataLogging();
                builder.UseLoggerFactory(GetLoggerFactory());
			});
        }

        private static ILoggerFactory GetLoggerFactory()
		{
			IServiceCollection serviceCollection = new ServiceCollection();
			serviceCollection.AddLogging(builder =>
				   builder.AddConsole()
						  .AddFilter(DbLoggerCategory.Database.Command.Name,
									 LogLevel.Information));
			return serviceCollection.BuildServiceProvider()
					.GetService<ILoggerFactory>();
		}
    }
}