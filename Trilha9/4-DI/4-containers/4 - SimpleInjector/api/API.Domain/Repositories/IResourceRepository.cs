using System.Collections.Generic;
using System.Linq;
using API.Domain.Entities;
using API.Domain.Repositories.Base;

namespace API.Domain.Repositories
{
    public interface IResourceRepository : IRepository<Resource>
    {
        List<Resource> GetAllByProperty(int propertyId);
    }
}