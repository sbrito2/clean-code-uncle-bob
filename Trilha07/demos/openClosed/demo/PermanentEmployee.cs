using demo;

namespace demo
{
    public class PermanentEmployee : Employee
    {
        public PermanentEmployee(int name, string id) : base(name, id)
        {

        }

        public override decimal CalculateBonus(decimal salary)
        {
            return  salary * .1M;
        }
    }
}