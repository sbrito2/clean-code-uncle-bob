using System;
using API.Presentation.API.Configurations.Logger;
using API.Presentation.API.Configurations.Logger.ElasticSearch;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace API.Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           Log.Logger = new LoggerConfiguration()
                .ConfigureSerilog()
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
