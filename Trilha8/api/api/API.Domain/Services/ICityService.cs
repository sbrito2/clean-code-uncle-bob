
using System.Collections.Generic;

namespace API.Domain.Services
{
    public interface ICityService
    {
        List<GenericComboboxModel> GetAllComboboxForm(string filter);
        bool Any(int id);
    }
}
