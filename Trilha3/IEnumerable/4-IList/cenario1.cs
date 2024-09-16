using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] array = new int[3];
        array[0] = 1;
        array[1] = 2;
        array[2] = 3;
        Display(array);

        List<int> list = new List<int>();
        list.Add(5);
        list.Add(7);
        list.Add(9);
        Display(list);
    }

    static void Display(IList<int> list)
    {
        Console.WriteLine("Count: {0}", list.Count);
        foreach (int value in list)
        {
            Console.WriteLine(value);
        }
    }
}