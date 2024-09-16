using System.Collections.Generic;
using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}