using API.Domain.Entities;
using API.Presentation.API.ViewModels;
using API.Presentation.API.ViewModels.ResourceType;
using Profile = AutoMapper.Profile;

namespace API.Presentation.API.AutoMapper
{
    public class ResourceTypeMapProfile : Profile
    {
        public ResourceTypeMapProfile()
        {
            CreateMap<ResourceTypeRequestViewModel, ResourceType>();  

            CreateMap<ResourceType, GenericComboboxViewModel>()
                .ForMember(x => x.Text, map => map.MapFrom(x => x.Description));
        }
    }
}