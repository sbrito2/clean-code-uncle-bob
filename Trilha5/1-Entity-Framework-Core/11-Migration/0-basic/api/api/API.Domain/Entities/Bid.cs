using System;
using System.ComponentModel.DataAnnotations.Schema;
using PDG.Domain.Entities.Base;

namespace PDG.Domain.Entities
{
    [Table("Bid")]
    public class Bid : Entity
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public int ActionId { get; set; }
        public Action Action { get; set; }
    }
}