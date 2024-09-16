
using System.Collections.Generic;

namespace API.Domain.Services
{
    public interface IStateService
    {
        List<GenericComboboxModel> GetAllComboboxForm(string filter);
    }
}
