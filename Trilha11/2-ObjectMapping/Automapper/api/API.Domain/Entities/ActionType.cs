using System;
using System.Collections.Generic;
using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class ActionType : Entity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Action> Actions { get; set; }
    }
}