using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class RentalCar
    {
        public int RecId { get; set; }
        public int RenId { get; set; }
        public int CusId { get; set; }

        public virtual Car Cus { get; set; }
        public virtual Rental Ren { get; set; }
    }
}
