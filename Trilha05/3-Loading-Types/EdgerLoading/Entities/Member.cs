using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoading.Entities
{
    public class Member
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Course { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string UniversityID { get; set; }
         public ICollection<Loan> Loans { get; set; }
    }
}