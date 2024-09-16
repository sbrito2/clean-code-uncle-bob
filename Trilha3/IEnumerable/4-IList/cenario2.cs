using System;
using System.Collections.Generic;

class Program
{
    static void Print(IList<string> list)
    {
        Console.WriteLine("Count: {0}", list.Count);
        foreach (string value in list)
        {
            Console.WriteLine(value);
        }
    }

    static void Main(string[] args)
    {

        string[] strArray = new string[2];
        strArray[0] = "Hello";
        strArray[1] = "World";
        Print(strArray);

        List<string> strList = new List<string>();
        strList.Add("Hello");
        strList.Add("World");
        Print(strList);
    }
}