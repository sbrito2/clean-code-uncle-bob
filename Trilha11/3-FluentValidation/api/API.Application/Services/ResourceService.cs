
using System.Collections.Generic;
using API.Domain.CoreLogic.Entities;
using API.Domain.Notification;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Domain.UnitOfWork;

namespace API.Application.Services
{
    public class ResourceService : Service<Resource>, IResourceService
    {
        private readonly IResourceRepository resourceRepository;
        private readonly IResourceTypeService resourceTypeService;

        public ResourceService(IResourceRepository resourceRepository, IResourceTypeService resourceTypeService, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        : base(resourceRepository, unitOfWork, notificationContext)
        {
            this.resourceRepository = resourceRepository;
            this.resourceTypeService = resourceTypeService;
        }

        public List<Resource> GetAllByProperty(int propertyId)
        {
            var resources = resourceRepository.GetAllByProperty(propertyId);

            return resources;
        }
    }
}
