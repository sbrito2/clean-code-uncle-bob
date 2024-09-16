using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PDG.Domain.Entities.Base;

namespace PDG.Domain.Entities
{
    [Table("PropertyType")]
    public class PropertyType : Entity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}