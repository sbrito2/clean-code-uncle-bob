using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.Notification;
using API.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Infraestructure.Data.Context
{
    public class UnitOfWork : DomainContext, IUnitOfWork
    {
        private readonly NotificationContext notificationContext;
        public UnitOfWork(DbContextOptions<DomainContext> options, NotificationContext notificationContext)
        : base(options)
        {
            this.notificationContext = notificationContext;
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public Entity Add(Entity entity)
        {
            if (!entity.IsValid())
            {
                notificationContext.AddNotifications(entity.ValidationResult);
                return null;
            }

            base.Add(entity);

            return entity;
        }

        public Entity Update(Entity entity)
        {
            if (!entity.IsValid())
            {
                notificationContext.AddNotifications(entity.ValidationResult);
                return null;
            }

            base.Update(entity);

            return entity;
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

        public bool Delete(Entity entity)
        {
            base.Entry(entity).State = EntityState.Deleted;

            return true;
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
                if (!entity.IsValid())
                {
                    notificationContext.AddNotifications(entity.ValidationResult);
                    return;
                }

                this.Update(entity);
            }
        }

        public void AddAll(IList<Entity> entities)
        {
            if (entities == null) return;

            foreach (var entity in entities)
            {
                if (!entity.IsValid())
                {
                    notificationContext.AddNotifications(entity.ValidationResult);
                    return;
                }

                this.Add(entity);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}