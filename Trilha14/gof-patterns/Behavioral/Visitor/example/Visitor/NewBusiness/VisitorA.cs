using System;
using Visitor.Interfaces;
using Visitor.OldBusiness;

namespace  Visitor.NewBusiness
{
    public class VisitorA : IVisitor
    {
        public void Visit(Soldier element)
        {
            Console.WriteLine(element.ExclusiveMethodOfSoldier() + " + new ConcreteVisitorA business");
        }

        public void Visit(Sergeante element)
        {
            Console.WriteLine(element.ExclusiveMethodOfSergeante() + " + new ConcreteVisitorA business");
        }

        public void Visit(Commander element)
        {
            Console.WriteLine(element.ExclusiveMethodOfCommander() + " + new ConcreteVisitorA business");
        }
    }
}