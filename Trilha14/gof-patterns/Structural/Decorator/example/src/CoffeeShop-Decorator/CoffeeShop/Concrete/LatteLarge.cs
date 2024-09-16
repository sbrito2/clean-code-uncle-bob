using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop;

namespace CoffeeShop.Concrete
{
    public class LatteLarge : Beverage
    {
        public LatteLarge()
        {
            this.Description = "Latte (Large)";
            this.Cost = 2.25M;
        }
    }
}
