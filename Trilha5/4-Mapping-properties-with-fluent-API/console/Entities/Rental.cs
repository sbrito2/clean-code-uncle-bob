

using System;
using System.Collections.Generic;

namespace console.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<RentalCar> RentalCars { get; set; }
    }
}