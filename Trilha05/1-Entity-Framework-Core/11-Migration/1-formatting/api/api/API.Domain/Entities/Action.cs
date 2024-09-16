using System;
using System.Collections.Generic;
using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class Action : Entity
    {
        public DateTime Date { get; set; }
        public decimal InitialBid { get; set; }
        public int ActionTypeId { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public ActionType ActionType { get; set; }
        public Property Property { get; set; }
        public User User { get; set; }
        public ICollection<Bid> Bids { get; set; }
    }
}