using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace console2.Entities
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}