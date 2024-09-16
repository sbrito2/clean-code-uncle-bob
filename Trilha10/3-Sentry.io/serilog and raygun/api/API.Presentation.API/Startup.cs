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
using Mindscape.Raygun4Net.AspNetCore;

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
            NativeDotNetInjector.RegisterServices(services);
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
            services.AddRaygun(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseRaygun();
            app.UseMvc();
            app.UseSerilogRequestLogging();
            app.UseEndpoints(endpoints =>{endpoints.MapControllers();});
        }
    }
}
