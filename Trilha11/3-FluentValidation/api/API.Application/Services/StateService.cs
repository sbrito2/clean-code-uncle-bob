
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
    public class StateService : Service<State>, IStateService
    {
        private readonly IStateRepository stateRepository;

        public StateService(IStateRepository stateRepository, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        : base(stateRepository, unitOfWork, notificationContext)
        {
            this.stateRepository = stateRepository;
        }

        public List<GenericComboboxModel> GetAllComboboxForm(string filter)
        {
            var combo =  stateRepository.GetAll(filter)
                .Select(x => new GenericComboboxModel { Id = x.Id, Text = x.Name } ).ToList();
            
            return combo;
        }
    }
}
