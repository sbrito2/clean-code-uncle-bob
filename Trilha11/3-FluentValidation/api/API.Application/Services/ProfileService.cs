
using API.Domain.CoreLogic.Entities;
using API.Domain.Notification;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Domain.UnitOfWork;

namespace API.Application.Services
{
    public class ProfileService : Service<Profile>, IProfileService
    {
        private readonly IProfileRepository profileRepository;

        public ProfileService(IProfileRepository profileRepository, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        : base(profileRepository, unitOfWork, notificationContext)
        {
            this.profileRepository = profileRepository;
        }
    }
}
