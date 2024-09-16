

using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Entities;

namespace API.Domain.Services
{
    public interface IResourceService
    {
        List<Resource> GetAllByProperty(int propertyId);
        bool Add(Resource property);
        bool Delete(int id);
    }
}
