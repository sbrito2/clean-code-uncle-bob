using System.Collections.Generic;

namespace console.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}