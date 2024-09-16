using API.Domain.CoreLogic.Entities;
using API.Presentation.API.ViewModels.ActionType;
using Profile = AutoMapper.Profile;

namespace API.Presentation.API.AutoMapper
{
    public class PropertyTypeMapProfile : Profile
    {
        public PropertyTypeMapProfile()
        {
            CreateMap<PropertyTypeRequestViewModel, PropertyType>();
        }
    }
}