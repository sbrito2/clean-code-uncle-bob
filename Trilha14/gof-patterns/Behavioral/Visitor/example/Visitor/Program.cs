using System;
using System.Collections.Generic;
using Visitor.Interfaces;
using Visitor.NewBusiness;
using Visitor.OldBusiness;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var components = new List<IComponent>()
            {
                new Soldier(),
                new Sergeante(),
                new Commander()
            };

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            var visitor1 = new VisitorA();
            Client.ClientCode(components,visitor1);

            Console.WriteLine();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new VisitorB();
            Client.ClientCode(components, visitor2);
        }
    }
}
