using System;
using System.Collections.Generic;

namespace apiRESTful.Models
{
    public partial class RentalCar
    {
        public int Id { get; set; }
        public int RenId { get; set; }
        public int CusId { get; set; }

        public virtual Car Cus { get; set; }
        public virtual Rental Ren { get; set; }
    }
}
