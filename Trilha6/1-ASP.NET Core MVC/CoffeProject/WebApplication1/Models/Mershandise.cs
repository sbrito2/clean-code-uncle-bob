using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Mershandise
    {
        public long MerId { get; set; }
        public string MerName { get; set; }
        public string MerDescription { get; set; }
        public decimal MerPrice { get; set; }
    }
}
