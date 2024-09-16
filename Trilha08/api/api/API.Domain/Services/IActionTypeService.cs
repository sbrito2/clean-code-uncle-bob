

using System.Collections.Generic;
using API.Domain.Entities;

namespace API.Domain.Services
{
    public interface IActionTypeService
    {
        List<GenericComboboxModel> GetAllComboboxForm();
        bool Add(ActionType property);
        bool Any (int id);
    }
}
