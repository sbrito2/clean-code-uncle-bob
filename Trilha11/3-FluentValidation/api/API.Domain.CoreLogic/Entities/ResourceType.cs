using System.Collections.Generic;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class ResourceType : Entity
    {
        public string Description { get; set; }
        public ICollection<Resource> Resources { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new ResourceTypeSpecification());
        }
    }
}