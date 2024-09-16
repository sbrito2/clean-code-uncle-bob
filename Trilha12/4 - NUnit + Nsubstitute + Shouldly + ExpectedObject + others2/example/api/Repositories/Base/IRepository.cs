using System.Collections.Generic;
using System.Threading.Tasks;
using API.Base;

namespace API.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(params object[] keys);
        TEntity Get(int id);
        List<TEntity> GetAll();
        bool Any(int id);
    }
}
