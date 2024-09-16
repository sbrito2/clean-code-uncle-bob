using System;

namespace API.Domain.Entities.Base
{
    public interface ISoftDeleteModel
    {
        bool Active { get; set; }
    }
}
