using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Entities.Base
{
    public class Entity : ITimestampedModel
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [DefaultValue("true")]
        public bool Active { get; set; }
        public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
