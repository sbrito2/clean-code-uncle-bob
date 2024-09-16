using System;
using System.Collections.Generic;

namespace console.Models
{
    public partial class CoffeGift
    {
        public CoffeGift()
        {
            BeverageType = new HashSet<BeverageType>();
        }

        public string CogName { get; set; }
        public string CogDescription { get; set; }
        public short CogAmount { get; set; }
        public long CogId { get; set; }

        public virtual ICollection<BeverageType> BeverageType { get; set; }
    }
}
