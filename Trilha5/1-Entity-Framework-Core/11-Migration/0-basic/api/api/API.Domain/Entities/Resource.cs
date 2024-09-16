using System.ComponentModel.DataAnnotations.Schema;
using PDG.Domain.Entities.Base;

namespace PDG.Domain.Entities
{
    [Table("Resource")]
    public class Resource : Entity
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int ResourceTypeId { get; set; }
        public int PropertyId { get; set; }
        public ResourceType ResourceType { get; set; }
        public Property Property { get; set; }
    }
}