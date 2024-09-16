using Microsoft.EntityFrameworkCore;
using API.Domain.Entities;
using API.Domain.Entities.Base;
using API.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Domain.Queries;
using API.Infraestructure.Data.Context;
using API.Infraestructure.Data.Repositories.Base;

namespace API.Infraestructure.Data.Repositories.Base
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>  where TEntity : Entity
    {
        public DbSet<TEntity> DbSet { get; set; }

        public Repository(DomainContext dataContext)
        : base (dataContext)
        {
            this.DataContext = dataContext;
            this.DbSet = this.DataContext.Set<TEntity>();
        }

        public TEntity Find(params object[] keys)
        {
            return this.DbSet.Find(keys);
        }

        public bool Any(int id)
        {
            return this.DbSet.Any(x => x.Id == id);
        }

        public IList<TEntity> GetAll()
        {
            return this.DbQuery.ToList();
        }
    }
}
