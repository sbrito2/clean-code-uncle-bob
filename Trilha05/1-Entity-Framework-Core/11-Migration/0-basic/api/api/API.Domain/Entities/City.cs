using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PDG.Domain.Entities.Base;

namespace PDG.Domain.Entities
{
    [Table("City")]
    public class City : Entity
    {
        public string Name { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}