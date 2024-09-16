using API.Domain.Entities;
using API.Presentation.API.ViewModels.ActionType;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace API.Presentation.API.Mapster
{
    public class ActionTypeMapProfile 
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            TypeAdapterConfig<ActionTypeRequestViewModel, ActionType>.NewConfig();
            app.UseMvc();
        }
    }
}