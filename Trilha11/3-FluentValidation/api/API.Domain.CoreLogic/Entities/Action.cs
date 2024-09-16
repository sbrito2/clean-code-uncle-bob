using System;
using System.Collections.Generic;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class Action : Entity
    {
        public DateTime Date { get; set; }
        public int ActionTypeId { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public ActionType ActionType { get; set; }
        public Property Property { get; set; }
        public User User { get; set; }
        public ICollection<Bid> Bids { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new ActionSpecification());
        }
    }
}