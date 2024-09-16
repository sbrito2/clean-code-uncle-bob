using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        IList<int> intList = new List<int>(){ 10, 20, 30, 40 };

        intList.Insert(1, 11);

        foreach (var el in intList)
            Console.Write(el);


        IList<int> intList2 = new List<int>(){ 10, 20, 30, 40 };

        intList2.Remove(10); //ICollection

        intList2.RemoveAt(2); //IList

        foreach (var el in intList2)
            Console.Write(el);
    }
}