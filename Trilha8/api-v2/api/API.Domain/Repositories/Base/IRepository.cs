using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain.Queries;

namespace API.Domain.Repositories.Base
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity Find(params object[] keys);
        bool Any(int id);
        IList<TEntity> GetAll();
    }
}
