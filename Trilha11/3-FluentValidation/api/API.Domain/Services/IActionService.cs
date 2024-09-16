

using System;
using System.Collections.Generic;
using Action = API.Domain.CoreLogic.Entities.Action;

namespace API.Domain.Services
{
    public interface IActionService : IService<Action>
    {
        List<Action> GetAll();
    }
}
