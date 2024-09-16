using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyLoading.Entities
{
    public class Loan
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Member")]
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public ICollection<LoanItem> LoanItems { get; set; }
    }
}