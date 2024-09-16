using System;
using console.Models;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new contextEntities())
            {

                // var result = context.IncrementProcedure(1);

                // Console.WriteLine(result);
            }
        }
    }
}
