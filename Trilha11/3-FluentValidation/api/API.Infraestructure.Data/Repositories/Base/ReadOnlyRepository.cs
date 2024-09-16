using Microsoft.EntityFrameworkCore;
using API.Domain.Queries;
using API.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using API.Infraestructure.Data.Context;
using API.Domain.CoreLogic.Entities.Base;

namespace API.Infraestructure.Data.Repositories.Base
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        public DomainContext DataContext { get; set; }
        public DbSet<TEntity> DbQuery { get; set; }

        protected ReadOnlyRepository(DomainContext dataContext)
        {
            this.DataContext = dataContext;
            this.DbQuery = this.DataContext.Set<TEntity>();
        }

        public TEntity FindAsNoTracking(int id)
        {
            return this.Query().First(x => x.Id == id);
        }

        public IList<TEntity> GetAllAsNoTracking()
        {
            return this.DbQuery.AsNoTracking().ToList();
        }

        public IQueryable<TEntity> Query()
        {
            return this.DbQuery.AsNoTracking().AsQueryable();
        }

        public PaginatedQueryResult<TEntity> ApplyPagination(IQueryable<TEntity> queryable, PaginatedQuery query)
        {
            var items = queryable.AsNoTracking().OrderBy(x => x.Id).Skip((Math.Max(query.Page, 1) - 1) * query.Items).Take(query.Items);
            return new PaginatedQueryResult<TEntity>(items.ToList(), queryable.Count());
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbQuery.AsNoTracking().Where(predicate);
        }

        public IQueryable<TEntity> Query(PaginatedQuery query)
        {
            var items = this.DbQuery.AsNoTracking().OrderBy(x => x.Id).Skip((Math.Max(query.Page, 1) - 1) * query.Items).Take(query.Items);
            var ListPage = new PaginatedQueryResult<TEntity>(items.ToList(), this.DbQuery.Count());
            return ListPage.Items.AsQueryable();
        }
    }
}
