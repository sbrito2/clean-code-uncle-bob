using System.Web.Http;
using API.CrossCutting.IoC;
using API.CrossCutting.Utils.Email;
using API.Presentation.API.Configurations.Swagger;
using API.Presentation.API.Extensions.Authentication;
using API.Presentation.API.Middlewares;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ninject;
using PDG.Presentation.API.Filters;
using Serilog;

namespace API.Presentation.API {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.Configure<EmailConfigurations> (Configuration.GetSection ("Email"));
            // NativeDotNetInjector.RegisterServices(services);
            services.AddResponseCaching ();
            services.AddControllers ();
            services.AddAutoMapper (typeof (Startup));
            services.AddSwaggerConfiguration ();
            services.AddJwtAuthenticationConfiguration (Configuration);
            services.AddAuthorizationConfiguration (Configuration);
            services.AddDbContextConfiguration (Configuration);
            services.AddGlobalMiddleware ();
            services.AddExceptionMiddleware ();
            services.AddMvcConfiguration (Configuration);
            services.AddControllersWithViews (options => {
                options.Filters.Add (typeof (NotificationFilter));
            });
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            var kernel = CreateKernel ();

            var webApiConfiguration = new HttpConfiguration();
            webApiConfiguration.MapHttpAttributeRoutes();
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(webApiConfiguration);

            if (env.IsDevelopment ()) { app.UseDeveloperExceptionPage (); }
            app.UseResponseCaching ();
            app.UseHttpsRedirection ();
            app.UseSwagger (); //https://localhost:5001/swagger
            app.UseSwaggerUI (c => { c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Testes Swagger"); });
            app.UseCors (x => x.AllowAnyOrigin ().AllowAnyMethod ().AllowAnyHeader ());
            app.UseRouting ();
            app.UseAuthentication ();
            app.UseAuthorization ();
            app.UseExceptionMiddleware ();
            app.UseGlobalMiddleware ();
            app.UseMvc ();
            app.UseSerilogRequestLogging ();
            app.UseEndpoints (endpoints => { endpoints.MapControllers (); });
        }

        public static IKernel CreateKernel () {

            var kernel = new StandardKernel (new NinjectBindings());

            return kernel;
        }
    }
}