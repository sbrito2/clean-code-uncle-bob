

using System.Collections.Generic;
using API.Domain.Entities;

namespace API.Domain.Services
{
    public interface IResourceTypeService : IService<ResourceType>
    {
        List<GenericComboboxModel> GetAllComboboxForm();
    }
}
