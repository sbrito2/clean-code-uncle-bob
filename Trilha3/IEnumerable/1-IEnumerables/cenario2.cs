using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Display(new List<bool> { true, false, true });
    }

    static void Display(IEnumerable<bool> argument)
    {
        foreach (bool value in argument)
        {
            Console.WriteLine(value);
        }
    }
}