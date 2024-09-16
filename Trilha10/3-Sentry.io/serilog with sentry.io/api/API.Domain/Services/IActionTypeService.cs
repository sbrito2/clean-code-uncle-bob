

using System.Collections.Generic;
using API.Domain.Entities;

namespace API.Domain.Services
{
    public interface IActionTypeService : IService<ActionType>
    {
        List<GenericComboboxModel> GetAllComboboxForm();
    }
}
