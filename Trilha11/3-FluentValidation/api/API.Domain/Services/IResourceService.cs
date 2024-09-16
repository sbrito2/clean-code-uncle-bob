

using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.Services
{
    public interface IResourceService : IService<Resource>
    {
        List<Resource> GetAllByProperty(int resourceId);
    }
}
