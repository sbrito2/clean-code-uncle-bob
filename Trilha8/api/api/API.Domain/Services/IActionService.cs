

using System;
using System.Collections.Generic;
using Action = API.Domain.Entities.Action;

namespace API.Domain.Services
{
    public interface IActionService
    {
        bool Add(Action property);
        List<Action> GetAll();
        Action Find(int id);
        bool Update(Action property);
        void Delete(int id);
    }
}
