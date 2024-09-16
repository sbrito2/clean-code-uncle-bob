
using System.Collections.Generic;
using System.Linq;
using API.Domain;
using API.Domain.Entities;
using API.Domain.Notification;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Domain.UnitOfWork;

namespace API.Application.Services
{
    public class ResourceTypeService : Service<ResourceType>, IResourceTypeService
    {
        private readonly IResourceTypeRepository resourceTypeRepository;

        public ResourceTypeService(IResourceTypeRepository resourceTypeRepository, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        : base(resourceTypeRepository, unitOfWork, notificationContext)
        {
            this.resourceTypeRepository = resourceTypeRepository;
        }

        public List<GenericComboboxModel> GetAllComboboxForm()
        {
            var combo =  resourceTypeRepository.Query()
                .Where(w => w.Active)
                .Select(x => new GenericComboboxModel { Id = x.Id, Text = x.Description } ).ToList();
            
            return combo;
        }
    }
}
