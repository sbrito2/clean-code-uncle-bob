using System;

/*  
    its hard to add new functions but also make it hard to add new data.
*/
public namespace C4COMMENTS.example
{
   class Employee
   {
        public string Name { get; set; }
        public Date Birth { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public List<Address> Addresses { get; }

        public void Add()
        {
        }

        public void Delete()
        {
        }

        public Employee GetEmployeeByID(int id)
        {
            return new Employee();
        }
   }
}