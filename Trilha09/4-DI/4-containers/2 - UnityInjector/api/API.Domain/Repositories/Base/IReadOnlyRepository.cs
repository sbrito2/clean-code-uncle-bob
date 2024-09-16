using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using API.Domain.Queries;

namespace API.Domain.Repositories.Base
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAllAsNoTracking();
        TEntity FindAsNoTracking(int id);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate);
        PaginatedQueryResult<TEntity> ApplyPagination(IQueryable<TEntity> queryable, PaginatedQuery query);
    }
}
