using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop;

namespace CoffeeShop.Concrete
{
    public class DripCoffeeMedium : Beverage
    {
        public DripCoffeeMedium()
        {
            this.Description = "Drip Coffee (Medium)";
            this.Cost = 2.0M;
        }
    }
}
