using System.Collections.Generic;
using System.Linq;
using API.Domain.Entities;
using API.Domain.Repositories.Base;

namespace API.Domain.Repositories
{
    public interface IStateRepository : IRepository<State>
    {
        List<State> GetAll(string filter);
    }
}