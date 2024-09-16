using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class Coffe
    {
        public Coffe()
        {
            Beverage = new HashSet<Beverage>();
        }
        [Display(Name = "Id")]
        public long CofId { get; set; }
        [Display(Name = "País")]
        public string CofCountry { get; set; }
        [Display(Name = "Descrição")]
        public string CofDescription { get; set; }

        public virtual ICollection<Beverage> Beverage { get; set; }
    }
}
