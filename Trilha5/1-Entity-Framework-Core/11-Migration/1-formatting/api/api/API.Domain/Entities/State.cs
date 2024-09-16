using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using API.Domain.Entities.Base;

namespace API.Domain.Entities
{
    [Table("State")]
    public class State : Entity
    {
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}