using api.Models;
using API.Base;
using API.Repositories.Base;

namespace API.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Properties
        Repository<Entity> EntityRepository { get; }
        #endregion
        
        #region Public methods
        Entity Add(Entity entity);
        Entity Update(Entity entity);
        bool Delete(Entity entity);
        void Commit(); 
        #endregion
    }
}