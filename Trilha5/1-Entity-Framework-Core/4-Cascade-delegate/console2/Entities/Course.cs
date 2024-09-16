using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace console2.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}