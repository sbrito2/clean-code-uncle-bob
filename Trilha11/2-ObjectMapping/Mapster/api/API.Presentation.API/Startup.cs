using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PDG.CrossCutting;
using API.Presentation.API.Middlewares;
using API.Presentation.API.Configurations.Swagger;
using API.Presentation.API.Extensions.Authentication;
using Serilog;
using API.CrossCutting.Utils.Email;
using PDG.Presentation.API.Filters;
using API.Presentation.API.Extensions.AuthenticationD;
using API.Presentation.API.Configurations.Logger.ElasticSearch;

namespace API.Presentation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<EmailConfigurations>(Configuration.GetSection("Email"));
            services.Configure<ElasticSearchLog>(Configuration.GetSection("ElasticSearchLogConfig"));
            NativeDotNetInjector.RegisterServices(services);
            services.AddResponseCaching();
            services.AddControllers(options => {
                options.Filters.Add(typeof(NotificationFilter));
                options.Filters.Add(typeof(ElasticSearchFilter));
            });
            services.AddSwaggerConfiguration();
            services.AddJwtAuthenticationConfiguration(Configuration);
            services.AddAuthorizationConfiguration(Configuration);
            services.AddDbContextConfiguration(Configuration);
            services.AddGlobalMiddleware();
			services.AddExceptionMiddleware();
            services.AddMvcConfiguration(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()){app.UseDeveloperExceptionPage();}
            app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Testes Swagger");
            });
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseExceptionMiddleware();
            app.UseGlobalMiddleware();
            app.UseMvc();
            app.UseEndpoints(endpoints =>{endpoints.MapControllers();});
        }
    }
}
