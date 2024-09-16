using System;
using console.Entities;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new CarRentalContext())
            {
               // Drop the database if it exists
                context.Database.EnsureDeleted();

                // Creates the database if not exists
                context.Database.EnsureCreated();
            }
        }
    }
}
