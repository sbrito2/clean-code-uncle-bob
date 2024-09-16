namespace Visitor.Interfaces
{
    public interface IComponent
    {
        void Accept(IVisitor visitor);
    }
}