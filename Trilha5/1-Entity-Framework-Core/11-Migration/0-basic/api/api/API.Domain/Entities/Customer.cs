using System.ComponentModel.DataAnnotations.Schema;
using PDG.Domain.Entities.Base;

namespace PDG.Domain.Entities
{
    [Table("Customer")]
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}