using System.Collections.Generic;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class PropertyType : Entity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<Property> Properties { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new PropertyTypeSpecification());
        }
    }
}