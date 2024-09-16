using System.Collections.Generic;
using API.Base;
using API.Domain.UnitOfWork;
using API.Repositories.Base;

namespace API.Services.Base
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        protected IRepository<TEntity> repository;
        protected readonly IUnitOfWork unitOfWork;
       
        public Service(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public virtual void Add(TEntity entity)
        {
            unitOfWork.Add(entity);
            unitOfWork.Commit();
        }

        public List<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public bool Any(int id)
        {
            return repository.Any(id);
        }

        public TEntity Find(int id)
        {
            return repository.Find(id);
        }

        public TEntity Find(params object[] keys)
        {
            return repository.Find(keys);
        }
        public virtual void Update(TEntity entity)
        {
            if(!Any(entity.Id))
            {
                return;
            }

            unitOfWork.Update(entity);
            unitOfWork.Commit();
        }

        public void Delete(TEntity entity)
        {
            if(!Any(entity.Id))
            {
                return;
            }

            unitOfWork.Delete(entity);
            unitOfWork.Commit();
        }

        public void Delete(params object[] keys)
        {
            TEntity entity = Find(keys);

            unitOfWork.Delete(entity);
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            TEntity entity = Find(id);

            unitOfWork.Delete(entity);
            unitOfWork.Commit();
        }
    }
}