using System;
using Visitor.Interfaces;
using Visitor.OldBusiness;

namespace  Visitor.NewBusiness
{
    public class VisitorB : IVisitor
    {
        public void Visit(Soldier element)
        {
            Console.WriteLine(element.ExclusiveMethodOfSoldier() + " + new ConcreteVisitorB business");
        }

        public void Visit(Sergeante element)
        {
            Console.WriteLine(element.ExclusiveMethodOfSergeante() + " + new ConcreteVisitorB business");
        }

        public void Visit(Commander element)
        {
            Console.WriteLine(element.ExclusiveMethodOfCommander() + " + new ConcreteVisitorB business");
        }
    }
}