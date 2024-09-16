using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using PDG.CrossCutting;
using API.Presentation.API.Middlewares;
using API.Presentation.API.Configurations.Swagger;
using API.Presentation.API.Extensions.Authentication;
using Serilog;
using API.CrossCutting.Utils.Email;
using PDG.Presentation.API.Filters;
using API.Domain.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Mvc;
using SimpleInjector.Integration.Web;

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
            // NativeDotNetInjector.RegisterServices(services);
            
            services.AddResponseCaching();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerConfiguration();
            services.AddJwtAuthenticationConfiguration(Configuration);
            services.AddAuthorizationConfiguration(Configuration);
            services.AddDbContextConfiguration(Configuration);
            services.AddGlobalMiddleware();
			services.AddExceptionMiddleware();
            services.AddMvcConfiguration(Configuration);
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(NotificationFilter));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 1. Create a new Simple Injector container
            var container = new Container();

            // 2. Configure the container (register)
            SimpleInjectorConfiguration.RegisterServices(container);

            // 3. Optionally verify the container's configuration.
            container.Verify();

            // 4. Register the container as MVC3 IDependencyResolver.
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            DependencyResolver.SetResolver(container);
            

            if (env.IsDevelopment()){app.UseDeveloperExceptionPage();}
            app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UseSwagger(); //https://localhost:5001/swagger
            app.UseSwaggerUI(c =>{c.SwaggerEndpoint("/swagger/v1/swagger.json","Testes Swagger");});
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseExceptionMiddleware();
            app.UseGlobalMiddleware();
            app.UseMvc();
            app.UseSerilogRequestLogging();
            app.UseEndpoints(endpoints =>{endpoints.MapControllers();});
        }
    }
}
