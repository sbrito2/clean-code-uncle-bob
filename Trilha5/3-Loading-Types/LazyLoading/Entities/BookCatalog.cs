using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoading.Entities
{
    public class BookCatalog
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Book")]
        public string BookID { get; set; }
        public string CatalogID { get; set; }
        public Book Book { get; set; }
    }
}