using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop;

namespace CoffeeShop.Concrete
{
    public class EspressoMedium : Beverage
    {
        public EspressoMedium()
        {
            this.Description = "Espresso (Medium)";
            this.Cost = 1.0M;
        }
    }
}
