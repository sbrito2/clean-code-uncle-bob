using baseConsole;

namespace OCPconsole
{
    public class FreelancerEmployee : Employee
    {
        public FreelancerEmployee(int name, string id) : base(name, id)
        {

        }

        public override decimal CalculateBonus(decimal salary)
        {
            return salary * .06M;
        }

        public override decimal GetMinimiumSalary()
        {
            return 1400;
        }
    }
}