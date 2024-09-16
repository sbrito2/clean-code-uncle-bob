using API.Domain.Entities;
using API.Presentation.API.ViewModels;
using API.Presentation.API.ViewModels.Customer;
using API.Presentation.API.ViewModels.Utils;
using Microsoft.AspNetCore.Builder;
using Mapster;
using Microsoft.AspNetCore.Hosting;

namespace API.Presentation.API.Mapster
{
    public class CustomerMapProfile
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            TypeAdapterConfig<Customer, CustomerResponseViewModel>.NewConfig()
                .Map(dest => dest.Data, src => src.CreatedAt)
                .Map(dest => dest.Property, (src => new GenericComboboxViewModel()
                {
                    Id = src.PropertyId,
                    Text = src.Property.Description
                }));

            app.UseMvc(); 
        }
    }
}