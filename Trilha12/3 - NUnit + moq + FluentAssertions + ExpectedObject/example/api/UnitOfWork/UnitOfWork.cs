using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using api.Models;
using API.Domain.UnitOfWork;
using API.Repositories.Base;
using API.Base;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly contextEntities context = null;
        private Repository<Entity> entityRepository;

        public UnitOfWork()
        {
            context = new contextEntities();
        }

        #region Properties's Creation
        public Repository<Entity> EntityRepository
        {
            get
            {
                if (this.entityRepository == null)
                    this.entityRepository = new Repository<Entity>(context);

                return entityRepository;
            }
        }
        #endregion

        #region Públic Methods

        public Entity Add(Entity entity)
        {
            context.Add(entity);

            return entity;
        }

        public Entity Update(Entity entity)
        {
            context.Update(entity);

            return entity;
        }
        
        public bool Delete(int id)
        {
            var dbset = context.Set<Entity>();

            var entity = dbset.FirstOrDefault(x => x.Id == id);
            
            if(entity == null)
            {
                return false;
            }

            context.Update(entity);

            return true;
        }

        public bool Delete(Entity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;

            return true;
        }

        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbException e)
            {
                //...
            }

        }

        #endregion

        #region Implementing IDiosposable
        private bool disposed = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    context.Dispose();
                }
            }
            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 

        #endregion
    }
}