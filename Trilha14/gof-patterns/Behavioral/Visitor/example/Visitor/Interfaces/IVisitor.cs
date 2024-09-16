using Visitor.OldBusiness;

namespace Visitor.Interfaces
{
    public interface IVisitor
    {
        void Visit(Soldier element);

        void Visit(Sergeante element);

        void Visit(Commander element);
    }
}