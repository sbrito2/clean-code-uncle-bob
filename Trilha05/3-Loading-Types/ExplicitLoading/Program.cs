using System;
using System.Collections.Generic;
using System.Linq;
using LazyLoading.Entities;

namespace LazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new LibraryContext())
            {
                // Drop the database if it exists
                context.Database.EnsureDeleted();

                // Creates the database if not exists
                context.Database.EnsureCreated();

                var book = new Book 
                {
                    Title = "Harry Potter and the Philosopher's Stone",
                    Author = new Author
                        {
                            Name = "J. K. Rowling",
                            Country = "England",
                            Description = "..."
                        }
                };

                context.Books.Add(book);
                context.SaveChanges();

                var searchedBook = context.Books
                        .Where(s => s.Author.ID > 1)
                        .FirstOrDefault<Book>();

                context.Entry(searchedBook).Reference(s => s.Author).Load(); // loads Author
                //context.Entry(Author).Collection(s => s.Books).Load(); // loads Courses collection
            }
        }
    }
}
