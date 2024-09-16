using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Decorators
{
    public class MilkSoyDecorator : BeverageDecorator
    {
        private const string _description = "Soy Milk";
        private const decimal _cost = 0M;

        public MilkSoyDecorator(Beverage b) : base(b)
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
