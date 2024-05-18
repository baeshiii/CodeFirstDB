using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDB
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        [Key] public int Code { get; set; }
    }

    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookContext())
            {
                Book book1 = new Book { Title = "Working with Databases", Author = "Baisa" };
                db.Books.Add(book1);

                Book book2 = new Book { Title = "Working with XML", Author = "Baisa" };
                db.Books.Add(book2);

                // random shananigans book3 to 5
                Book book3 = new Book { Title = "Working with XML", Author = "Maleniza" }; 
                db.Books.Add(book3);

                Book book4 = new Book { Title = "Working with XML", Author = "Cinco" };
                db.Books.Add(book4);

                Book book5 = new Book { Title = "Working with XML", Author = "Magbitang" };
                db.Books.Add(book5);

                db.SaveChanges();

                var query = from b in db.Books
                            orderby b.Title
                            select b;

                Console.WriteLine("All books in the database:");
                foreach (var b in query)
                {
                    Console.WriteLine($"{b.Title} by {b.Author}, code={b.Code}");
                }

                Console.WriteLine("Press a key to exit...");
                Console.ReadKey();
            }   
        }
    }
}
