using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PDG.Domain.Entities.Base;

namespace PDG.Domain.Entities
{
    [Table("ActionType")]
    public class ActionType : Entity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<Action> Actions { get; set; }
    }
}