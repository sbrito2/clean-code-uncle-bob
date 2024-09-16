using System;
using System.Collections.Generic;

namespace console.Models
{
    public partial class Coffe
    {
        public Coffe()
        {
            Beverage = new HashSet<Beverage>();
        }

        public long CofId { get; set; }
        public string CofCountry { get; set; }
        public string CofDescription { get; set; }

        public virtual ICollection<Beverage> Beverage { get; set; }
    }
}
