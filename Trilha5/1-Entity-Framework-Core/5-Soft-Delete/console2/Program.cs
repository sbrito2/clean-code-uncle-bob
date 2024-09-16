using System;
using System.Linq;
using console2.Entities;
using Microsoft.EntityFrameworkCore;

namespace console2
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertStudents();
            SoftDelete(1);
            GetStudents();
            GetDeleteStudents();
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

                var student = context.Students.Add(new Student
                {
                    Name = "Dulce Maria",
                    Age = 22,
                    Course = course
                });

                context.SaveChanges();
            }
        }

        private static void SoftDelete(int id)
        {
            using(var context = new MyContext())
            {
                var studentdb = context.Students.FirstOrDefault();
                context.Remove(studentdb);

                context.SaveChanges();
            }
        }

        private static void GetStudents()
        {
            var context = new MyContext();

            var deletedStudents = context.Students
                .ToList();
            
            Console.WriteLine ($"\n Students List:");
            deletedStudents.ForEach(x => {
                Console.WriteLine ($"ID: {x.Id} - Name: {x.Name}");
            });
        } 

        private static void GetDeleteStudents()
        {
            var context = new MyContext();

            var deletedStudents = context.Students
                .IgnoreQueryFilters()
                .Where(x => x.IsDeleted)
                .ToList();
            
            Console.WriteLine($"\n Deleted Students List:");
            deletedStudents.ForEach(x => {
                Console.WriteLine ($"ID: {x.Id} - Name: {x.Name}");
            });
        } 
    }
}
