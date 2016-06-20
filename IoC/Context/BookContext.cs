using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IoC.Context
{
    public class BookContext : DbContext
    {
        public BookContext() : base("DefaultConnection") { }

        public DbSet<Book> Books { get; set; }
    }


    // Hекомендуется уходить от использования жесткосвязанных компонентов к слабосвязанным.
    // Для этого определим новый интерфейс IRepository
    public interface IRepository
    {
        void Save(Book b);
        IEnumerable<Book> List();
        Book Get(int id);
    }
    public class BookRepository : IDisposable, IRepository
    {
        private BookContext db;
        // методы
        public BookRepository(BookContext context)
        {
            db = context;
        }
        public void Save(Book b)
        {
            db.Books.Add(b);
            db.SaveChanges();
        }
        public IEnumerable<Book> List()
        {
            return db.Books;
        }
        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }



}