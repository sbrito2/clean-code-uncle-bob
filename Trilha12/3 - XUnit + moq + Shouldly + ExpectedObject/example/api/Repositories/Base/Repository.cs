using api.Models;
using API.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace API.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public contextEntities DataContext { get; set; }
        public DbSet<TEntity> DbSet { get; set; }

        public Repository(contextEntities dataContext)
        {
            this.DataContext = dataContext;
            this.DbSet = this.DataContext.Set<TEntity>();
        }

        public TEntity Find(params object[] keys)
        {
            return this.DbSet.Find(keys);
        }

        public TEntity Get(int id)
        {
            return this.DbSet.FirstOrDefault(x => x.Id == id);
        }

        public List<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        }

        public bool Any(int id)
        {
           return this.DbSet.Any(x => x.Id == id);
        }
    }
}
