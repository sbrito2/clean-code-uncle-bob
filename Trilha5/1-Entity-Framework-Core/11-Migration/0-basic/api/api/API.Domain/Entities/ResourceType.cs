using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PDG.Domain.Entities.Base;

namespace PDG.Domain.Entities
{
    [Table("ResourceType")]
    public class ResourceType : Entity
    {
        public string Description { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}