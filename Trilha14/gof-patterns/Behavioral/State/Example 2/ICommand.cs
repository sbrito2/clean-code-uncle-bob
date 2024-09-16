namespace Example_2
{
    public interface ICommand
    {
        void Open();
        void Resolve();
        void Close();
        bool Delete();
        void Print();
    }
}