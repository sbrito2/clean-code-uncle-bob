using baseConsole;

namespace demo
{
    public class TemporaryEmployee : Employee
    {
        public TemporaryEmployee(int name, string id) : base(name, id)
        {

        }

        public override decimal CalculateBonus(decimal salary)
        {
            return  salary * .1M;
        }

        public override decimal GetMinimiumSalary()
        {
            return 4000;
        }
    }
}