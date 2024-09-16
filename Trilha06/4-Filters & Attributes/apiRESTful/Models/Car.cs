using System;
using System.Collections.Generic;

namespace apiRESTful.Models
{
    public partial class Car
    {
        public Car()
        {
            RentalCar = new HashSet<RentalCar>();
        }

        public int CarId { get; set; }
        public string CarPlate { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public decimal CarPrice { get; set; }

        public virtual ICollection<RentalCar> RentalCar { get; set; }
    }
}
