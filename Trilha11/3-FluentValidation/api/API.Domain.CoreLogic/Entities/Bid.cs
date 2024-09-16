using System;
using API.Domain.CoreLogic.Entities.Base;
using API.Domain.CoreLogic.Specifications;

namespace API.Domain.CoreLogic.Entities
{
    public class Bid : Entity
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public int ActionId { get; set; }
        public Action Action { get; set; }

        public override bool IsValid()
        {
            return IsValid(this, new BidSpecification());
        }
    }
}