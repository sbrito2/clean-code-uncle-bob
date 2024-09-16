

using System.Collections.Generic;
using API.Domain.Entities;

namespace API.Domain.Services
{
    public interface IPropertyTypeService : IService<PropertyType>
    {
        List<GenericComboboxModel> GetAllComboboxForm();
    }
}
