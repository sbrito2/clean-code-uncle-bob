using System;
using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class Bid : Entity
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public int ActionId { get; set; }
        public Action Action { get; set; }
    }
}