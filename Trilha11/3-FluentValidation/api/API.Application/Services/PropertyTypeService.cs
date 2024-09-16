
using System.Collections.Generic;
using System.Linq;
using API.Domain;
using API.Domain.CoreLogic.Entities;
using API.Domain.Notification;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Domain.UnitOfWork;

namespace API.Application.Services
{
    public class PropertyTypeService : Service<PropertyType>, IPropertyTypeService
    {
        private readonly IPropertyTypeRepository propertyTypeRepository;

        public PropertyTypeService(IPropertyTypeRepository propertyTypeRepository, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        : base(propertyTypeRepository, unitOfWork, notificationContext)
        {
            this.propertyTypeRepository = propertyTypeRepository;
        }

        public List<GenericComboboxModel> GetAllComboboxForm()
        {
            var combo =  propertyTypeRepository.Query()
                .Where(w => w.Active)
                .Select(x => new GenericComboboxModel { Id = x.Id, Text = x.Description } ).ToList();
            
            return combo;
        }
    }
}