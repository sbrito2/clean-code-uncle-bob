using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PDG.Domain.Entities.Base;

namespace PDG.Domain.Entities
{
    [Table("Profile")]
    public class Profile : Entity
    {
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}