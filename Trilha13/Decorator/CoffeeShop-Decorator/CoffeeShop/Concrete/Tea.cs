using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop;

namespace CoffeeShop.Concrete
{
    public class Tea : Beverage
    {
        public Tea()
        {
            this.Description = "Tea (Single Bag)";
            this.Cost = 1.75M;
        }
    }
}
