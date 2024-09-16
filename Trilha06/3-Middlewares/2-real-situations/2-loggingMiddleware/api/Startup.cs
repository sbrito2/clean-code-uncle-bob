using System;
using api.Middlewares;
using api.Implementations;
using api.Interfaces;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using api.Middlewares.Logging;
using Microsoft.Extensions.Logging.Console;

namespace api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // services.AddJwtValidationConfiguration();
            services.AddRateLimitConfiguration(Configuration);
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Ativando middlewares para uso do Swagger
            //https://localhost:5001/swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Testes Swagger");
            });

            app.UseIpRateLimiting();
            app.UseClientRateLimiting();
            app.UseGlobalExceptionHandlerMiddlewareExtension(loggerFactory);

            var logger = loggerFactory.CreateLogger<ConsoleLoggerProvider>();
            logger.LogInformation("******************************************************************");
            logger.LogInformation("*** Executando médoto Configure() do LOG..." + DateTime.Now.ToLongTimeString()); 
            logger.LogInformation("******************************************************************");
            
            loggerFactory.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                    LogLevel = LogLevel.Information
            }));
        }
    }
}
