using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoading.Entities
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public ICollection<LoanItem> LoanItems { get; set; }
    }
}