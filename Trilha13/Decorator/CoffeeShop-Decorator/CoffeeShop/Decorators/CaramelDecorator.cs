using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Decorators
{
    public class CaramelDecorator : BeverageDecorator
    {
        private const string _description = "Caramel";
        private const decimal _cost = 1.0M;

        public CaramelDecorator(Beverage b) : base(b) {}

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

        public string GetDecoratorDescriptionOnly()
        {
            return _description;
        }
    }
}
