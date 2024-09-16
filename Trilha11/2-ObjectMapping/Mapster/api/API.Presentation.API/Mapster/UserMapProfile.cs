
using System;
using API.Presentation.API.ViewModels.User;
using API.Domain.Entities;
using API.Presentation.API.ViewModels.Login;
using API.Domain.Queries.Login;
using API.Domain.Projections.Email;
using API.Presentation.API.ViewModels.Utils;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace API.Presentation.API.Mapster
{
    public class UserMapProfile 
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            TypeAdapterConfig<UserRequestViewModel, User>.NewConfig();

            TypeAdapterConfig<User, UserReponseViewModel>.NewConfig()
                .Map(dest => dest.Profile, src => new GenericComboboxViewModel()
                {
                    Id = src.ProfileId,
                    Text = src.Profile.Description
                });

            TypeAdapterConfig<LoginViewModel, LoginQuery>.NewConfig();

            TypeAdapterConfig<EmailViewModel, EmailProjectionModel>.NewConfig();
        }
    }
}