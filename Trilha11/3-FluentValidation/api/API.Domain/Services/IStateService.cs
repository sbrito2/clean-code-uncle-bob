
using System.Collections.Generic;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.Services
{
    public interface IStateService : IService<State>
    {
        List<GenericComboboxModel> GetAllComboboxForm(string filter);
    }
}
