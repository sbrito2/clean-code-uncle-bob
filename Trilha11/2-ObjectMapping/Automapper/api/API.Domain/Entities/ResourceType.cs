using System.Collections.Generic;
using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class ResourceType : Entity
    {
        public string Description { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}