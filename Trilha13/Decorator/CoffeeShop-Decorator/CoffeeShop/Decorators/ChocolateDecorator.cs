using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Decorators
{
    class ChocolateDecorator : BeverageDecorator
    {
        public ChocolateDecorator(Beverage beverage) : base(beverage)
        {
            this.Description = "Chocolate";
            this.Cost = 5m;
        }
    }
}
