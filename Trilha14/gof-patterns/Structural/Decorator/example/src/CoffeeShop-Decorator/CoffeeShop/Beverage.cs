using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    public abstract class Beverage
    {
        public virtual string Description { get; set; } = "Unknown Beverage";
        public virtual decimal Cost { get; set; } = 0.0M;
    }
}
