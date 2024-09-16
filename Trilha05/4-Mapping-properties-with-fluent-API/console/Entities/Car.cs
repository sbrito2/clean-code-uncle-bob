using System.Collections.Generic;

namespace console.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public ICollection<RentalCar> RentalCars { get; set; }
    }
}