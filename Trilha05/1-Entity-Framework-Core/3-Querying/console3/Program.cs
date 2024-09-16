using System;
using System.Linq;
using console3.Entities;

namespace console3
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new contextEntities())
            {
                var coffe = context.Coffe.First();

                var coffes = context.Coffe;

                var Mershandise = context.Mershandise.Where(x => x.MerPrice < 10);

                var response = context.BeverageType.All(x => x.CogId.HasValue);
            }
        }
    }
}
