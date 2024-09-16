using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Presentation.API.Extensions.Authentication
{
    public static class JwtValidationConfiguration
    {
        public static void AddJwtAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {        
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            { 
                var KeyByteArray = Encoding.ASCII.GetBytes(configuration["TokenConfigurations:Key"]);
                var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(KeyByteArray);

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true
                };
            });
        }
    }
}