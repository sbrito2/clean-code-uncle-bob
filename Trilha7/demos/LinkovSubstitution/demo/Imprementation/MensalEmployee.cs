using baseConsole;
using demo.Interface;

namespace demo
{
    public class MensalEmployee : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MensalEmployee(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public decimal GetMinimiumSalary()
        {
            return 3999;
        }

        public override string ToString()
        {
            return string.Format("Id : {0} {1}", this.Id, this.Name);
        }
    }
}