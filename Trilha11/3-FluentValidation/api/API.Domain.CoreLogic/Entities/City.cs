using System.Collections.Generic;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public ICollection<Property> Properties { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new CitySpecification());
        }
    }
}