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

                //Loading Book only
                IList<Book> books = context.Books.ToList<Book>();

                Book mybook = books[0];

                //Loads author for particular Book only (seperate SQL query)
                Author author = mybook.Author;

                context.SaveChanges();
            }
        }
    }
}
