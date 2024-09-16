using System.Collections;
using System.Collections.Generic;
using API.Domain.Entities.Base;
using API.Domain.Notification;
using API.Domain.Queries;
using API.Domain.Repositories.Base;
using API.Domain.Services;
using API.Domain.UnitOfWork;

namespace API.Application.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        protected IRepository<TEntity> repository;
        protected readonly IUnitOfWork unitOfWork;
        protected readonly NotificationContext notificationContext;
       
        public Service(IRepository<TEntity> repository, IUnitOfWork unitOfWork, NotificationContext notificationContext)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.notificationContext = notificationContext;
        }

        public virtual void Add(TEntity entity)
        {
            unitOfWork.Add(entity);
        }

        public bool Any(int id)
        {
            return repository.Any(id);
        }

        public TEntity Find(int id)
        {
            TEntity entity = repository.Find(id);

            return entity;
        }

        public TEntity Find(params object[] keys)
        {
            TEntity entity = repository.Find(keys);

            if (entity == null)
            {
                notificationContext.AddNotFoundNotification("Não encontrado");
            }

            return entity;
        }

        public IList<TEntity> GetAll(PaginatedQuery query)
        {
            return repository.GetAll();
        }

        public virtual void Update(TEntity entity)
        {
            if(!Any(entity.Id))
            {
                notificationContext.AddNotFoundNotification("Não encontrado.");
                return;
            }

            unitOfWork.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            if(!Any(entity.Id))
            {
                notificationContext.AddNotFoundNotification("Não encontrado.");
                return;
            }

            unitOfWork.Delete(entity);
        }

        public void Delete(params object[] keys)
        {
            TEntity entity = Find(keys);

            unitOfWork.Delete(entity);
        }

        public void Delete(int id)
        {
            TEntity entity = Find(id);

            unitOfWork.Delete(entity);
        }
    }
}