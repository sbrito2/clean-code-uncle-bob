using System;
using System.Linq;
using API.Domain.Permissions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Presentation.API.Extensions.Authentication
{
    public static class AuthorizationConfiguration
    {
        public static void AddAuthorizationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {    
            services.AddAuthorization(options =>
            {
                foreach (ActionRoles role in Enum.GetValues(typeof(ActionRoles)).Cast<ActionRoles>())
                {
                    string roleName = $"Role_{role.ToString("g")}";
                    options.AddPolicy(roleName, policy => policy.RequireClaim("ProfileId", role.ToString("d")));
                }
            });
        }
    }
}