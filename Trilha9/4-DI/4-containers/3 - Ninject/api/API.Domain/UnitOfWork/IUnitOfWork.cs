using System.Collections.Generic;
using API.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace API.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Entity Add(Entity entity);
        void AddAll(IList<Entity> entities);
        Entity Update(Entity entity);
        void UpdateAll(IList<Entity> entities);
        Entity Delete(Entity entity);
        void DeleteAll(IList<Entity> entities);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
