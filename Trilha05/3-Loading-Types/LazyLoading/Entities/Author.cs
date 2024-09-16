using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoading.Entities
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        public string Country { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}