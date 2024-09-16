using System;
using System.Collections.Generic;

namespace apiRESTful.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Rental = new HashSet<Rental>();
        }

        public int CusId { get; set; }
        public string CusName { get; set; }
        public string CarCpf { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
    }
}
