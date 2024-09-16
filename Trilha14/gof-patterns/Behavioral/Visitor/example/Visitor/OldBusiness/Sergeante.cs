using System.Collections.Generic;
using Visitor.Interfaces;

namespace  Visitor.OldBusiness
{
    public class Sergeante : IComponent
    {
        public string ExclusiveMethodOfSergeante()
        {
            return "ExclusiveMethodOfSergeanteClass";
        }

        public static void ClientCode(List<IComponent> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}