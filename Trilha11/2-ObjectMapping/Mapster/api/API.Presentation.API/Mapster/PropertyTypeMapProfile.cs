using API.Domain.Entities;
using API.Presentation.API.ViewModels.ActionType;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace API.Presentation.API.Mapster
{
    public class PropertyTypeMapProfile
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            TypeAdapterConfig<PropertyTypeRequestViewModel, PropertyType>.NewConfig();

            app.UseMvc(); 
        }
    }
}