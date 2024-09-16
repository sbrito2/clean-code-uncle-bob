

using System.Collections.Generic;
using API.Domain.Entities;

namespace API.Domain.Services
{
    public interface IResourceTypeService
    {
        List<GenericComboboxModel> GetAllComboboxForm();
        bool Add(ResourceType property);
        bool Any(int id);
    }
}
