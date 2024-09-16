using System.Collections.Generic;
using API.Domain.Queries;

namespace API.Domain.Services
{
    public interface IService<TEntity>
    {
        void Add(TEntity entity);
        bool Any(int id);
        TEntity Find(int id);
        TEntity Find(params object[] keys);
        IList<TEntity> GetAll(PaginatedQuery query);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(params object[] keys);
        void Delete(int id);
    }
}