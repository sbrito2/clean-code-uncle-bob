using System;
using System.Collections.Generic;

namespace console3.Entities
{
    public partial class BeverageType
    {
        public BeverageType()
        {
            Beverage = new HashSet<Beverage>();
        }

        public long BetId { get; set; }
        public string BetName { get; set; }
        public string BetDescription { get; set; }
        public long? CogId { get; set; }

        public virtual CoffeGift Cog { get; set; }
        public virtual ICollection<Beverage> Beverage { get; set; }
    }
}
