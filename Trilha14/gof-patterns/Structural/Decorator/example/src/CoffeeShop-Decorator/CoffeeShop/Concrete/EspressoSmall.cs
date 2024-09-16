using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop;

namespace CoffeeShop.Concrete
{
    public class EspressoSmall : Beverage
    {
        public EspressoSmall()
        {
            this.Description = "Espresso (Small)";
            this.Cost = 1.0M;
        }
    }
}
