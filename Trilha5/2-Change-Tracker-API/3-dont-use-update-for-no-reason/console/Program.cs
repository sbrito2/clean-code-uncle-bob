using System;
using System.Linq;
using console.Models;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public void UpdateSpecificField()
        {
            using (var context = new contextEntities())
            {
                // Query: as a result we got a entity that is tracked
                var coffe = context.Coffe.FirstOrDefault();

                // We change just a field from this entity
                coffe.CofCountry = "Brasil";

                // EF will detect the change and update only the column that has changed.
                context.SaveChanges();
            }
        }

        public void UpdateAllEntityFields()
        {
            using (var context = new contextEntities())
            {
                // Query for the entity.
               var coffe = context.Coffe.FirstOrDefault();

                // Entity is now tracked. Make a change to it.
                coffe.CofCountry = "Brasil";

                // The Update method marks the entity and all its properties as modified
                context.Update(coffe);

                // This SaveChanges will send updates for all fields
                context.SaveChanges();
            }
        }
    }
}

/* The trade-off
There is a trade-off between these two approaches to disconnected entities. The first requires only one round 
trip to the database, but all columns will be updated. The second has two database round trips, but missing
 entities are handled more cleanly (it is easy to return NotFound()) and only values actually changed are 
 updated. This trade-off is discussed more in the disconnected entities documentation. 
 */