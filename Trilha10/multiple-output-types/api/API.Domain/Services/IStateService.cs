
using System.Collections.Generic;
using API.Domain.Entities;

namespace API.Domain.Services
{
    public interface IStateService : IService<State>
    {
        List<GenericComboboxModel> GetAllComboboxForm(string filter);
    }
}
