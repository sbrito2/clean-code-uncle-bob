
using System.Linq;
using System.Runtime.CompilerServices;
using API.Presentation.API.ViewModels.User;
using API.Domain.Entities;
using API.Presentation.API.ViewModels.Property;
using API.Presentation.API.ViewModels.Utils;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace API.Presentation.API.Mapster
{
    public class PropertyMapProfile : Profile
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            TypeAdapterConfig<PropertyRequestViewModel, Property>.NewConfig();

            TypeAdapterConfig<Property, PropertyResponseViewModel>.NewConfig()
            // .Map(x => x.PhotoUrls, map => map.MapFrom<PhotoUrlResolver<Property>, string>(y => y.PhotosPath))
            .Map(x => x.ResourcesTypes, x => x.Resources.Select(y => y.ResourceType))
            .Map(x => x.PropertyType, x => new GenericComboboxViewModel()
                {
                    Id = x.PropertyTypeId,
                    Text = x.PropertyType.Description
                })
            .Map(x => x.ActionType, x => new GenericComboboxViewModel()
                {
                    Id = x.ActionTypeId ?? 0,
                    Text = x.ActionType.Description
                });  

            TypeAdapterConfig<Property, PropertyViewModel>.NewConfig()
            // .Map(x => x.PhotoUrl, map => map.MapFrom<RandomPhotoUrlResolver<Property>, string>(y => y.PhotosPath))
            .Map(x => x.ResourcesTypes, x => x.Resources.Select(y => y.ResourceType))
            .Map(x => x.PropertyType, x => new GenericComboboxViewModel()
                {
                    Id = x.PropertyTypeId,
                    Text = x.PropertyType.Description
                })
            .Map(x => x.ActionType, x => new GenericComboboxViewModel()
                {
                    Id = x.ActionTypeId ?? 0,
                    Text = x.ActionType.Description
                }); 

            app.UseMvc(); 
        }
    }
}