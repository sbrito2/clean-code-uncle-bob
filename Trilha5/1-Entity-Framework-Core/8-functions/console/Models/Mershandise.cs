using System;
using System.Collections.Generic;

namespace console.Models
{
    public partial class Mershandise
    {
        public long MerId { get; set; }
        public string MerName { get; set; }
        public string MerDescription { get; set; }
        public decimal MerPrice { get; set; }
    }
}
