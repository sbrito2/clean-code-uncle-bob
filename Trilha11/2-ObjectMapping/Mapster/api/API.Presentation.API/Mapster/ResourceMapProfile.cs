using API.Domain.Entities;
using API.Presentation.API.ViewModels.Resource;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace API.Presentation.API.Mapster
{
    public class ResourceMapProfile 
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            TypeAdapterConfig<ResourceRequestViewModel, Resource>.NewConfig();

            app.UseMvc();  
        }
    }
}