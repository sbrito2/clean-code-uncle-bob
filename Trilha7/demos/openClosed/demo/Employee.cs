namespace demo
{
    public abstract class Employee
    {   
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee()
        {

        }

        public Employee(int id, string name)
        {
            this.Id = id; this.Name = name;
        }

        public abstract decimal CalculateBonus(decimal salaray);

        public override string ToString()
        {
            return string.Format("Id : {0} {1}", this.Id, this.Name);
        }
    }
}