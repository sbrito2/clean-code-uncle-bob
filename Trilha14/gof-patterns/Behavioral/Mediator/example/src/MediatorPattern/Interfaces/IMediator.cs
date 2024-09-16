namespace MediatorPattern.Interfaces
{
    public interface IMediator
    {
        void Notify(object sender, string ev);
    }
}