using System;
using System.Linq;
using System.Collections.Generic;
using API.Domain.Entities;
using API.Domain.Queries.Login;
using API.Domain.Queries.Login.Results;
using API.Domain.Repositories;
using API.Domain.Services;
using API.CrossCutting.Utils.Security.Exceptions;
using API.Domain.UnitOfWork;
using API.Domain.Queries;
using API.Domain.Notification;
using Microsoft.Extensions.Configuration;

namespace API.Application.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IProfileService profileService;
        private readonly JwtTokenGeneratorService jwtTokenGeneratorService;
        private readonly int itensPerPageDefault;

        public UserService(IUserRepository userRepository, IConfiguration config, JwtTokenGeneratorService jwtTokenGeneratorService, IProfileService profileService, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        : base(userRepository, unitOfWork, notificationContext)
        {
            this.userRepository = userRepository;
            this.jwtTokenGeneratorService = jwtTokenGeneratorService;
            this.profileService = profileService;
            this.itensPerPageDefault = config.GetValue<int>("ItensPerPageDefault");
        }

        public override void Add(User user)
        {
            if(!profileService.Any(user.ProfileId))
            {
                this.notificationContext.AddNotFoundNotification("Perfil de usuário não encontrado.");
                return;
            }

            if(!userRepository.CheckEmailIsFree(user.Email))
            {
                this.notificationContext.AddNotFoundNotification("Esse e-mail já está em uso por outro usuário.");
                return;
            }

            unitOfWork.Add(user);
            unitOfWork.SaveChanges();

            return;
        }

        public List<User> GetAll()
        {
            return userRepository.GetAllAndTheirProfile();
        }

        public override void Update(User user)
        {
            if(!profileService.Any(user.ProfileId))
            {
                this.notificationContext.AddNotFoundNotification("Perfil de usuário não encontrado.");
                return;
            }

            if(!userRepository.CheckEmailIsFree(user.Email))
            {
                this.notificationContext.AddNotFoundNotification("Esse e-mail já está em uso por outro usuário.");
                return;
            }

            unitOfWork.Update(user);
            unitOfWork.SaveChanges();
        }

        public LoginQueryResult Authenticate(LoginQuery query)
        {
            User user = userRepository.GetUserByEmail(query.Email);
            
            LoginQueryResult response = new LoginQueryResult();
            if(user == default (User))
            {
                return response.SetNotSucceeded();
            }

            if(query.Password != user.Password)
            {
                return response.SetNotSucceeded();
            }

            response.Token = jwtTokenGeneratorService.GenerateToken(user);

            return response.SetSucceeded();
        }

        public PaginatedQueryResult<User> Index(int page, string filter)
        {
            var query = new GenericPaginatedQuery<string>(page, itensPerPageDefault, filter);
            var users = userRepository.GetAll(query);

            return users;
        }
    }
}
