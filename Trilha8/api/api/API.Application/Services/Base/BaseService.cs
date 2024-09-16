using System.Collections;
using API.Domain.Entities.Base;
using API.Domain.Notification;
using API.Domain.Services;
using API.Domain.UnitOfWork;

namespace API.Application.Services
{
    public class Service : IService
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly NotificationContext notificationContext;
       

        public Service(IUnitOfWork unitOfWork, NotificationContext notificationContext)
        {
            this.unitOfWork = unitOfWork;
            this.notificationContext = notificationContext;
        }
    }
}