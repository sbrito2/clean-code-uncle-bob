using System;
using System.Collections.Generic;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class ActionType : Entity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Action> Actions { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new ActionTypeSpecification());
        }
    }
}