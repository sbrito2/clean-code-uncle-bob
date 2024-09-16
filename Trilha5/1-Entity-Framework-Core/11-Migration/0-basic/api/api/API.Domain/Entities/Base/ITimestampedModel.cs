using System;

namespace PDG.Domain.Entities.Base
{
    public interface ITimestampedModel
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
