using System.Collections.Generic;
using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    public class Profile : Entity
    {
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}