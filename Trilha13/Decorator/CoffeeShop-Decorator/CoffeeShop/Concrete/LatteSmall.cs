using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop;

namespace CoffeeShop.Concrete
{
    public class LatteSmall : Beverage
    {
        public LatteSmall()
        {
            this.Description = "Latte (Small)";
            this.Cost = 1.75M;
        }
    }
}
