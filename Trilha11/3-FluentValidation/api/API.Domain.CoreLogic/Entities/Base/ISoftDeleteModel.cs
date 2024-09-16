using System;

namespace API.Domain.CoreLogic.Entities.Base
{
    public interface ISoftDeleteModel
    {
        bool Active { get; set; }
    }
}
