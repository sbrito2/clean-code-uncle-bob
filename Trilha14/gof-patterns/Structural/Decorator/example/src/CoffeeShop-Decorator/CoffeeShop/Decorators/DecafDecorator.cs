using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Decorators
{
    public class DecafDecorator : BeverageDecorator
    {
        private const string _description = "Decaf";
        private const decimal _cost = 0M;

        public DecafDecorator(Beverage b) : base(b)
        {
        }

        public override string Description
        {
            get
            {
                return $"{this.GetWrappedEntity().Description}, {_description}";
            }
        }

        public override decimal Cost
        {
            get
            {
                return this.GetWrappedEntity().Cost + _cost;
            }
        }

    }
}
