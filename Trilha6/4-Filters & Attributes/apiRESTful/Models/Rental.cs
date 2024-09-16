using System;
using System.Collections.Generic;

namespace apiRESTful.Models
{
    public partial class Rental
    {
        public Rental()
        {
            RentalCar = new HashSet<RentalCar>();
        }

        public int RentId { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentReturn { get; set; }
        public int RentStatus { get; set; }
        public int CusId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<RentalCar> RentalCar { get; set; }
    }
}
