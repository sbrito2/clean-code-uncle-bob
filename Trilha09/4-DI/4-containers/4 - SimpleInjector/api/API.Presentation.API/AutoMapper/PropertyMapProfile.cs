
using System.Linq;
using System.Runtime.CompilerServices;
using API.Presentation.API.ViewModels.User;
using API.Domain.Entities;
using Profile = AutoMapper.Profile;
using API.Presentation.API.ViewModels.Property;
using API.Presentation.API.ViewModels;
using API.Presentation.API.AutoMapper.CustomResolver;

namespace API.Presentation.API.AutoMapper
{
    public class PropertyMapProfile : Profile
    {
        public PropertyMapProfile()
        {
            CreateMap<PropertyRequestViewModel, Property>();

            CreateMap<Property, PropertyResponseViewModel>()
            .ForMember(x => x.PhotoUrls, map => map.MapFrom<PhotoUrlResolver<Property>, string>(y => y.PhotosPath))
            .ForMember(x => x.ResourcesTypes, map => map.MapFrom(x => x.Resources.Select(y => y.ResourceType)))
            .ForMember(x => x.PropertyType, map => map.MapFrom(x => new GenericComboboxViewModel()
                {
                    Id = x.PropertyTypeId,
                    Text = x.PropertyType.Description
                }))
            .ForMember(x => x.ActionType, map => map.MapFrom(x => new GenericComboboxViewModel()
                {
                    Id = x.ActionTypeId ?? 0,
                    Text = x.ActionType.Description
                }));  

            CreateMap<Property, PropertyViewModel>()
            .ForMember(x => x.PhotoUrl, map => map.MapFrom<RamdonPhotoUrlResolver<Property>, string>(y => y.PhotosPath))
            .ForMember(x => x.ResourcesTypes, map => map.MapFrom(x => x.Resources.Select(y => y.ResourceType)))
            .ForMember(x => x.PropertyType, map => map.MapFrom(x => new GenericComboboxViewModel()
                {
                    Id = x.PropertyTypeId,
                    Text = x.PropertyType.Description
                }))
            .ForMember(x => x.ActionType, map => map.MapFrom(x => new GenericComboboxViewModel()
                {
                    Id = x.ActionTypeId ?? 0,
                    Text = x.ActionType.Description
                })); 
        }
    }
}