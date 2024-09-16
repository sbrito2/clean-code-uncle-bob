using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace console.Entities
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Key] [Column("CUS_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] [Column("CUS_NAME", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required] [Column("CAR_CPF", TypeName = "varchar(10)")]
        public string Cpf { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}