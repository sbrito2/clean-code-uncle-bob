namespace demo.Interface
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal GetMinimiumSalary();
    }
}