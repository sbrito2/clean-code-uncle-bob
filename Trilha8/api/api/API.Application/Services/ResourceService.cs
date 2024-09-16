
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using API.Domain.Entities;
using API.Domain.Notification;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Domain.UnitOfWork;
using API.Infra.Utils.Security.Exceptions;

namespace API.Application.Services
{
    public class ResourceService : Service, IResourceService
    {
        private readonly IResourceRepository resourceRepository;
        private readonly IResourceTypeService resourceTypeService;

        public ResourceService(IResourceRepository resourceRepository, IResourceTypeService resourceTypeService, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        : base(unitOfWork, notificationContext)
        {
            this.resourceRepository = resourceRepository;
            this.resourceTypeService = resourceTypeService;
        }

        public bool Add(Resource property)
        {
            if(!resourceTypeService.Any(property.ResourceTypeId))
            {
                this.notificationContext.AddNotFoundNotification("Tipo de recurso não encontrado.");
                return false;
            }

            unitOfWork.Add(property);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var resource = resourceRepository.Find(id);
            
            if(resource == null)
            {
                this.notificationContext.AddNotFoundNotification("Tipo de recurso não encontrado.");
                return false;
            }

            unitOfWork.Delete(resource);
            unitOfWork.SaveChanges();

            return true;
        }

        public List<Resource> GetAllByProperty(int propertyId)
        {
            var resources = resourceRepository.GetAllByProperty(propertyId);

            return resources;
        }
    }
}
