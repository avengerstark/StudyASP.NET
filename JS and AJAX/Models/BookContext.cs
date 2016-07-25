using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JS_and_AJAX.Models
{
    public class BookContext : DbContext
    {
        public BookContext() : base("BookStoreDb") { }

        public DbSet<Book> Books { get; set; }

        static BookContext()
        {
            Database.SetInitializer<BookContext>(new BookInitializer());
        }
    }


    class BookInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            Book book1 = new Book { Name = "Три товарища", Author = "Ремарк", Price = 3000 };
            Book book2 = new Book { Name = "1984", Author = "Джордж Оруэлл", Price = 2000 };
            Book book3 = new Book { Name = "Sea wolf", Author = "Jack London", Price = 4000 };
            Book book4 = new Book { Name = "Триумфальная арка", Author = "Ремарк", Price = 3000 };
            Book book5 = new Book { Name = "Время жить и время умирать", Author = "Ремарк", Price = 3000 };

            context.Books.AddRange(new List<Book> { book1, book2, book3, book4, book5 });
            context.SaveChanges();
        }
    }

}