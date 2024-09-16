using System.Collections.Generic;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class State : Entity
    {
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public ICollection<City> Cities { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new StateSpecification());
        }
    }
}