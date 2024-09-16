/* We can use IQueryable in a similar way as IEnumerable */
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // List and array can be converted to IQueryable.
        List<int> list = new List<int>();
        list.Add(0);
        list.Add(1);

        int[] array = new int[2];
        array[0] = 0;
        array[1] = 1;

        // We can use IQueryable to treat collections with one type.
        Test(list.AsQueryable());
        Test(array.AsQueryable());
    }

    static void Test(IQueryable<int> items)
    {
        Console.WriteLine($"Average: {items.Average()}");
        Console.WriteLine($"Sum: {items.Sum()}");
    }
}