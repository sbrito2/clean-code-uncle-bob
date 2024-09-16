

using System.Collections.Generic;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.Services
{
    public interface IActionTypeService : IService<ActionType>
    {
        List<GenericComboboxModel> GetAllComboboxForm();
    }
}
