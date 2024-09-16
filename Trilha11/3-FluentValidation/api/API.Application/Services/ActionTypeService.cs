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
    public class ActionTypeService : Service<ActionType>,  IActionTypeService
    {
        private readonly IActionTypeRepository actionTypeRepository;

        public ActionTypeService(IActionTypeRepository actionTypeRepository, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        : base(actionTypeRepository, unitOfWork, notificationContext)
        {
            this.actionTypeRepository = actionTypeRepository;
        }

        public List<GenericComboboxModel> GetAllComboboxForm()
        {
           var combo =  actionTypeRepository.Query()
                .Where(w => w.Active)
                .Select(x => new GenericComboboxModel { Id = x.Id, Text = x.Description } ).ToList();
            
            return combo;
        }
    }
}
