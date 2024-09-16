using System;
using System.Collections.Generic;
using System.Linq;
using LazyLoading.Entities;
using Microsoft.EntityFrameworkCore;

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

                //a query for one type of entity also loads related entities as part of the query
                IList<Book> books = context.Books.Include(x => x.Author).ToList<Book>();

                context.SaveChanges();
            }
        }
    }
}
