using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var values = new int[] { 5, 10, 20 };
        // We can convert an int array to IQueryable.
        // ... And then we can pass it to Queryable and methods like Average.
        double result = Queryable.Average(values.AsQueryable());
        Console.WriteLine(result);
    }
}