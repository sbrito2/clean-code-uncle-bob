using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Entities.Base;
using API.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Infraestructure.Data.Context
{
    public class UnitOfWork : DomainContext, IUnitOfWork
    {
        public UnitOfWork(DbContextOptions<DomainContext> options)
        : base(options)
        {
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public Entity Add(Entity entity)
        {
            base.Add(entity);

            return null;
        }

        public Entity Update(Entity entity)
        {
            base.Update(entity);

            return null;
        }
        public bool Delete(int id)
        {
            var dbset = base.Set<Entity>();

            var entity = dbset.FirstOrDefault(x => x.Id == id);
            
            if(entity == null)
            {
                return false;
            }

            base.Update(entity);

            return true;
        }

        public Entity Delete(Entity entity)
        {
            base.Entry(entity).State = EntityState.Deleted;

            return null;
        }

        public void DeleteAll(IList<Entity> entities)
        {
            if (entities == null) return;

            foreach (var entity in entities)
            {
                this.Add(entity);
            }
        }

        public void UpdateAll(IList<Entity> entities)
        {
            if (entities == null) return;

            foreach (var entity in entities)
            {
                this.Update(entity);
            }
        }

        public void AddAll(IList<Entity> entities)
        {
            if (entities == null) return;

            foreach (var entity in entities)
            {
                this.Add(entity);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}