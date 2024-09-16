

using System.Collections.Generic;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.Services
{
    public interface IPropertyTypeService : IService<PropertyType>
    {
        List<GenericComboboxModel> GetAllComboboxForm();
    }
}
