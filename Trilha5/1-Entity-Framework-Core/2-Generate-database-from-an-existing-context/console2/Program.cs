using System;
using console2.Entities;

namespace console2
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertStudents();
        }

        private static void InsertStudents()
        {
            using(var context = new MyContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                var course = new Course
                {
                    Name = "Computer Science",
                    Price = 20000.0
                };

                context.Courses.Add(course);

                context.Students.Add(new Student
                {
                    Name = "Larissa Martins",
                    Age = 21,
                    Course = course
                });

                context.Students.Add(new Student
                {
                    Name = "Dulce Maria",
                    Age = 22,
                    Course = course
                });

                context.SaveChanges();
            }
        }
    }
}
