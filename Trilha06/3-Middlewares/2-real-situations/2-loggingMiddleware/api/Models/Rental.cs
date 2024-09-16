using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Rental
    {
        public Rental()
        {
            RentalCar = new HashSet<RentalCar>();
        }

        public int RenId { get; set; }
        public DateTime RenStart { get; set; }
        public DateTime RenReturn { get; set; }
        public int RenStatus { get; set; }
        public int CusId { get; set; }

        public virtual Customer Cus { get; set; }
        public virtual ICollection<RentalCar> RentalCar { get; set; }
    }
}
