using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace console.Entities
{
    [Table("RENTAL_CAR")]
    public class RentalCar
    {
        [Key] [Column("REC_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] [Column("REN_ID")]
        [ForeignKey("Rental")]
        public int RentalId { get; set; }

        [Required] [Column("CUS_ID")]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Rental Rental { get; set; }
        public Car Car  { get; set; } 
    }
}