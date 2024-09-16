
using System;
using AutoMapper;
using API.Presentation.API.ViewModels.User;
using API.Domain.Entities;
using Profile = AutoMapper.Profile;
using API.Presentation.API.ViewModels;
using API.Presentation.API.ViewModels.Login;
using API.Domain.Queries.Login;
using API.Domain.Projections.Email;
using API.Presentation.API.ViewModels.Utils;

namespace API.Presentation.API.AutoMapper
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserRequestViewModel, User>()
                .ForMember(x => x.UpdatedAt, map => map.MapFrom(x => DateTime.Now))
                .ForMember(x => x.CreatedAt, map => map.MapFrom(x => DateTime.Now));  

            CreateMap<User, UserReponseViewModel>()
                .ForMember(x => x.Profile, map => map.MapFrom(x => new GenericComboboxViewModel()
                {
                    Id = x.ProfileId,
                    Text = x.Profile.Description
                }));  

            CreateMap<LoginViewModel, LoginQuery>();

            CreateMap<EmailViewModel, EmailProjectionModel>();
        }
    }
}