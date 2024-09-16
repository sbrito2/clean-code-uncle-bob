using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Configurations.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Mestre dos Leilões - api", Version = "v1" });

                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference 
                                { 
                                    Type = ReferenceType.SecurityScheme, 
                                    Id = "Bearer" 
                                }
                            },
                            new string[] {}

                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerRoutes(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Mestre dos leilões V1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }
    }
}
