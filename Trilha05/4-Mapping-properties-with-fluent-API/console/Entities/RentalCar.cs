namespace console.Entities
{
    public class RentalCar
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public Rental Rental { get; set; }
        public Car Car  { get; set; } 
    }
}