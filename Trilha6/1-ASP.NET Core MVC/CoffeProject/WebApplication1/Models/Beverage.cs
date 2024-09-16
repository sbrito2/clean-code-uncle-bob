using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Beverage
    {
        public long BevId { get; set; }
        public long BetId { get; set; }
        public long? CofId { get; set; }
        public bool BevMilk { get; set; }
        public bool BevSoy { get; set; }
        public DateTime BevDate { get; set; }

        public virtual BeverageType Bet { get; set; }
        public virtual Coffe Cof { get; set; }
    }
}
