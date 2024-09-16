using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace console.Entities
{
    [Table("CAR")]
    public class Car
    {
        [Key] [Column("CAR_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] [Column("CAR_PLATE", TypeName = "varchar(8)")]
        public string Plate { get; set; }

        [Required] [Column("CAR_MODEL", TypeName = "varchar(50)")]
        public string Model { get; set; }

        [Required] [Column("CAR_COLOR", TypeName = "varchar(50)")]
        public string Color { get; set; }

        [Required] [Column("CAR_PRICE", TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public ICollection<RentalCar> RentalCars { get; set; }
    }
}