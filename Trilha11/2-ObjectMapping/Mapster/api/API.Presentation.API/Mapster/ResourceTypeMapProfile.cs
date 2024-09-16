using API.Domain.Entities;
using API.Presentation.API.ViewModels.ResourceType;
using API.Presentation.API.ViewModels.Utils;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace API.Presentation.API.Mapster
{
    public class ResourceTypeMapProfile 
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            TypeAdapterConfig<ResourceTypeRequestViewModel, ResourceType>.NewConfig();

            TypeAdapterConfig<ResourceType, GenericComboboxViewModel>.NewConfig()
                .Map(dest => dest.Text, src => src.Description);

            app.UseMvc();  
        }
    }
}