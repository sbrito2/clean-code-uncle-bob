

using System.Collections.Generic;
using API.Domain.Entities;

namespace API.Domain.Services
{
    public interface IPropertyTypeService
    {
        bool Any (int id);
        bool Add(PropertyType property);
        List<GenericComboboxModel> GetAllComboboxForm();
    }
}
