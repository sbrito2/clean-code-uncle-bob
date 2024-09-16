using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace console2.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}