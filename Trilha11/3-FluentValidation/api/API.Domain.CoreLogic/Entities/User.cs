using System;
using System.Collections.Generic;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Description { get; set; }
        public DateTime? Birth { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public ICollection<Action> Actions { get; set; }
        public ICollection<Property> Properties { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new UserSpecification());
        }
    }
}