using System;
using System.Collections.Generic;
using demo.Interface;
using demo;
using OCPconsole;

namespace baseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IEmployee> employees = new List<IEmployee>();

            employees.Add(new TemporaryEmployee(1, "Anne"));
            employees.Add(new FreelancerEmployee(2, "Lucas"));
            employees.Add(new MensalEmployee(3, "Carol"));
            
            foreach(var employee in employees)
            {
                Console.WriteLine(string.Format("Employee {0} Bonus: {1}",
                employee.ToString(),
                employee.GetMinimiumSalary().ToString()));
            }

            Console.ReadLine();
        }
    }
}
