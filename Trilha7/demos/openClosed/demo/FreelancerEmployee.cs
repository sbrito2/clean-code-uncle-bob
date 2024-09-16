using demo;

namespace demo
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
    }
}