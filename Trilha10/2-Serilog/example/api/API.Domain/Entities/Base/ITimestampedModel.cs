using System;

namespace API.Domain.Entities.Base
{
    public interface ITimestampedModel
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        int? UserId { get; set; }
    }
}
