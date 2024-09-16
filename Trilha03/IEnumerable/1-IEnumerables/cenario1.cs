using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Part A: query expression.
        IEnumerable<int> result = from value in Enumerable.Range(0, 2)
                                  select value;

        // Part B: loop over IEnumerable.
        foreach (int value in result)
        {
            Console.WriteLine(value);
        }

        // Part C: we can use extension methods on IEnumerable.
        double average = result.Average();

        // ... Convert IEnumerable.
        List<int> list = result.ToList();
        int[] array = result.ToArray();
    }
}