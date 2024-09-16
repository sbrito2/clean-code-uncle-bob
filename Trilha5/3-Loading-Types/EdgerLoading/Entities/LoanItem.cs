using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoading.Entities
{
    public class LoanItem
    {
        [Key]
        public int ID { get; set; }
        public DateTime ReturnDate { get; set; }
        [ForeignKey("Loan")]
        public int LoanID { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public Loan Loan { get; set; }
        public Book Book { get; set; }
    }
}