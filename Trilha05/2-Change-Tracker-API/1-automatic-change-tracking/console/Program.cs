using System;
using console.Models;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            contextEntities myContext = new contextEntities();
            BeverageType coffe = new BeverageType(){BetName = "Mochaaa", BetDescription = "O Mocha é uma versão ainda mais achocolatada do Cappuccino. Na prática, é uma mistura entre um Cappuccino e chocolate quente."};
            myContext.Add(coffe);

            Console.WriteLine("-----After Adding ------");
            foreach(var tracker in myContext.ChangeTracker.Entries<BeverageType>())
            {
                Console.WriteLine(tracker.State);
            }

            BeverageType modifiedBerageType =  myContext.BeverageType.Find((long) 1);
            if(modifiedBerageType != null)
            {
                modifiedBerageType.BetName = "Mocha";
            }

            Console.WriteLine("-----After Modification ------");
            foreach(var tracker in myContext.ChangeTracker.Entries<BeverageType>())
            {
                Console.WriteLine(tracker.State);
            }

            BeverageType researchedBerageType =  myContext.BeverageType.Find((long) 2);
            if(researchedBerageType != null)
            {
                myContext.Remove(researchedBerageType);
            }

            Console.WriteLine("-----After Removal ------");
            foreach(var tracker in myContext.ChangeTracker.Entries<BeverageType>())
            {
                Console.WriteLine(tracker.State);
            }
        }
    }
}
