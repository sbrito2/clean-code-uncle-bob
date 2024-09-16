using System;
using API.Domain.Notification;

namespace API.Domain.Entities.Base
{
    public partial class Entity : NotificationContext, ITimestampedModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserId { get; set; }
    }
}
