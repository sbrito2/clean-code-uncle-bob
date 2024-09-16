

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace console.Entities
{
    [Table("RENTAL")]
    public class Rental
    {
        [Key] [Column("REN_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] [Column("REN_START")]
        public DateTime StartDate { get; set; }

        [Required] [Column("REN_RETURN")]
        public DateTime ReturnDate { get; set; }

        [Required] [Column("REN_STATUS")]
        public int Status { get; set; }

        [Required] [Column("CUS_ID")]
        [ForeignKey("Custumer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<RentalCar> RentalCars { get; set; }
    }
}