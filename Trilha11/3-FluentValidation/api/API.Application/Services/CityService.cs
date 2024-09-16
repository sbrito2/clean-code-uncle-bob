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
    public class CityService :  Service<City>, ICityService
    {
        private readonly ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        : base(cityRepository, unitOfWork, notificationContext)
        {
            this.cityRepository = cityRepository;
        }

        public List<GenericComboboxModel> GetAllComboboxForm(string filter)
        {
            var combo =  cityRepository.GetAll(filter)
                .Select(x => new GenericComboboxModel { Id = x.Id, Text = x.Name } ).ToList();
            
            return combo;
        }
    }
}
