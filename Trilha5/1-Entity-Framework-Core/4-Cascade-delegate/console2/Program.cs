using System;
using System.Linq;
using console2.Entities;

namespace console2
{
    class Program
    {
        static void Main(string[] args)
        {
            Insert();
            Delete();
        }

        private static void Insert()
        {
            using(var context = new MyContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                context.Students.Add(new Student
                {
                    Name = "Larissa Martins",
                    Age = 21,
                    Course = new Course
                    {
                        Name = "Computer Science2",
                        Price = 20000.0
                    }
                });

                context.SaveChanges();
            }
        }

        private static void Delete()
        {
            using(var context = new MyContext())
            {
                var course = context.Courses.FirstOrDefault();

                context.Remove(course);

                context.SaveChanges();
            }
        }
    }
}
