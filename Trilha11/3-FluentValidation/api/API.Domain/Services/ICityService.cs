
using System.Collections.Generic;
using API.Domain.CoreLogic.Entities;

namespace API.Domain.Services
{
    public interface ICityService : IService<City>
    {
        List<GenericComboboxModel> GetAllComboboxForm(string filter);
    }
}
