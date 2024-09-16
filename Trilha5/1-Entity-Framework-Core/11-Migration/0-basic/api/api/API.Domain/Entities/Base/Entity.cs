using System;

namespace PDG.Domain.Entities.Base
{
    public class Entity : ITimestampedModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
