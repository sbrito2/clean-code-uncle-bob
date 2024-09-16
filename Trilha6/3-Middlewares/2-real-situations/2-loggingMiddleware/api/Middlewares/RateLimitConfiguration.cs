using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;

namespace api.Middlewares
{
    public static class RateLimitingConfiguration
    {
        public static void AddRateLimitConfiguration(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddOptions();
            services.AddMemoryCache();

            services.Configure<IpRateLimitOptions>(_configuration.GetSection("IpRateLimiting"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            services.Configure<ClientRateLimitOptions>(_configuration.GetSection("ClientRateLimiting"));
            services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();

            services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            var optd = new ClientRateLimitOptions();
            _configuration.GetSection("ClientRateLimiting").Bind(optd);

            services.AddMvc((options) => 
            {
                options.EnableEndpointRouting = false;

            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }
    }
}