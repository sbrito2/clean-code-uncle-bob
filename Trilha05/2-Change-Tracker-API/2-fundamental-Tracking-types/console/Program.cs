using System;
using System.Diagnostics;
using System.Linq;
using console.Models;
using Microsoft.EntityFrameworkCore;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            contextEntities myContext = new contextEntities();
            BeverageType coffe = new BeverageType(){BetName = "Mochaaa", BetDescription = "O Mocha é uma versão ainda mais achocolatada do Cappuccino. Na prática, é uma mistura entre um Cappuccino e chocolate quente."};
            myContext.Add(coffe);

            var stopWatch = Stopwatch.StartNew();

            //Default tracking
            using (var db = new contextEntities())
            {

                var coffes = db.BeverageTypes.Where(x => x.BetId % 2 < 2).ToList();
                
                Console.WriteLine($"{stopWatch.Elapsed} - Tracking");

                Console.WriteLine($"{db.ChangeTracker.Entries().Count()} Tracked Entities.");
            
            }
            Console.WriteLine();
            stopWatch = Stopwatch.StartNew();

            //no tracking per single query
            using(var db = new contextEntities())
            {
                var beverageType = db.BeverageTypes.AsNoTracking().Where(x => x.BetId % 2 < 2).ToList();

                Console.WriteLine($"{stopWatch.Elapsed} - No tracking per query");

                Console.WriteLine($"{db.ChangeTracker.Entries().Count()} Tracked Entities.");
            }
            Console.WriteLine();
            stopWatch = Stopwatch.StartNew();

            //No tracking on a DbContext instance level
            using (var db = new contextEntities())
            {
                db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var coffes = db.BeverageTypes.Where(x => x.BetId % 2 < 2).ToList();
                
                Console.WriteLine($"{stopWatch.Elapsed} - No tracking per context");

                Console.WriteLine($"{db.ChangeTracker.Entries().Count()} Tracked Entities.");
            
            }
            Console.WriteLine();
            stopWatch = Stopwatch.StartNew();

            //Tracking in projection without a data model  
            using (var db = new contextEntities())
            {

                var coffes = db.BeverageTypes
                    .Where(x => x.BetId % 2 < 2)
                    .Select(x => new { x.BetId, x.BetName })
                    .ToList();
                
                Console.WriteLine($"{stopWatch.Elapsed} - Tracking in projection without a data model");

                Console.WriteLine($"{db.ChangeTracker.Entries().Count()} Tracked Entities.");
            
            }
            Console.WriteLine();
            stopWatch = Stopwatch.StartNew();

            //No Tracking in projection without a data model  
            using (var db = new contextEntities())
            {

                var coffes = db.BeverageTypes
                    .AsNoTracking()
                    .Where(x => x.BetId % 2 < 2)
                    .Select(x => new { x.BetId, x.BetName })
                    .ToList();
                
                Console.WriteLine($"{stopWatch.Elapsed} - No Tracking in projection without a data model");

                Console.WriteLine($"{db.ChangeTracker.Entries().Count()} Tracked Entities.");
            
            }
            Console.WriteLine();
            stopWatch = Stopwatch.StartNew();

            //Tracking in projection with a data model  
            using (var db = new contextEntities())
            {

                var coffes = db.BeverageTypes
                    .Where(x => x.BetId % 2 < 2)
                    .Select(x => new { x.BetId, x.BetName, x.Cog })
                    .ToList();
                
                Console.WriteLine($"{stopWatch.Elapsed} - Tracking in projection with a data model");

                Console.WriteLine($"{db.ChangeTracker.Entries().Count()} Tracked Entities.");
            
            }
            Console.WriteLine();
            stopWatch = Stopwatch.StartNew();

            //No Tracking in projection with a data model  
            using (var db = new contextEntities())
            {

                var coffes = db.BeverageTypes
                    .AsNoTracking()
                    .Where(x => x.BetId % 2 < 2)
                    .Select(x => new { x.BetId, x.BetName, x.Cog })
                    .ToList();
                
                Console.WriteLine($"{stopWatch.Elapsed} - No Tracking in projection with a data model");

                Console.WriteLine($"{db.ChangeTracker.Entries().Count()} Tracked Entities.");
            
            }
        }
    }
}
