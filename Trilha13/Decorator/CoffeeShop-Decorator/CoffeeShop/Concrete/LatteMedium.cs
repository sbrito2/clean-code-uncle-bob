using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop;

namespace CoffeeShop.Concrete
{
    public class LatteMedium : Beverage
    {
        public LatteMedium()
        {
            this.Description = "Latte (Medium)";
            this.Cost = 2.0M;
        }
    }
}
