using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Decorators
{
    public abstract class BeverageDecorator : Beverage
    {
        private Beverage _beverage;
        protected BeverageDecorator(Beverage b)
        {
            _beverage = b;
        }

        protected Beverage GetWrappedEntity() { return this._beverage; }
    }
}
