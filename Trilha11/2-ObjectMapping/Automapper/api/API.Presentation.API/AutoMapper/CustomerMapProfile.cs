using API.Domain.Entities;
using API.Presentation.API.ViewModels;
using API.Presentation.API.ViewModels.Customer;
using API.Presentation.API.ViewModels.Utils;
using AutoMapper;
using Profile = AutoMapper.Profile;

namespace API.Presentation.API.AutoMapper
{
    public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<CustomerRequestViewModel, Customer>();  

            CreateMap<Customer, CustomerResponseViewModel>()
                .ForMember(x => x.Data, map => map.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.Property, map => map.MapFrom(x => new GenericComboboxViewModel()
                {
                    Id = x.PropertyId,
                    Text = x.Property.Description
                }));  
        }
    }
}