using API.Domain.Entities;
using API.Presentation.API.ViewModels.ActionType;
using API.Presentation.API.ViewModels.ResourceType;
using Profile = AutoMapper.Profile;

namespace API.Presentation.API.AutoMapper
{
    public class ActionTypeMapProfile : Profile
    {
        public ActionTypeMapProfile()
        {
            CreateMap<ActionTypeRequestViewModel, ActionType>();  
        }
    }
}