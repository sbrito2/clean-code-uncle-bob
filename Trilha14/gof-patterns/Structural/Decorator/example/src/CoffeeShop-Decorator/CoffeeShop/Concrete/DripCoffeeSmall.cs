using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop;

namespace CoffeeShop.Concrete
{
    public class DripCoffeeSmall : Beverage
    {
        public DripCoffeeSmall()
        {
            this.Description = "Drip Coffee (Small)";
            this.Cost = 1.0M;
        }
    }
}

