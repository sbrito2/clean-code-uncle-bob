using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop;

namespace CoffeeShop.Concrete
{
    public class EspressoLarge : Beverage
    {
        public EspressoLarge()
        {
            this.Description = "Espresso (Large)";
            this.Cost = 1.0M;
        }
    }
}
