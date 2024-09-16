using System.Collections.Generic;
using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class PropertyType : Entity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}