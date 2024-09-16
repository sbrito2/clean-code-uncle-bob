using API.Domain.Entities;
using API.Presentation.API.ViewModels.Resource;
using Profile = AutoMapper.Profile;

namespace API.Presentation.API.AutoMapper
{
    public class ResourceMapProfile : Profile
    {
        public ResourceMapProfile()
        {
            CreateMap<ResourceRequestViewModel, Resource>();  
        }
    }
}