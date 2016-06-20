using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

// Инициализация базы данных

namespace EntityFrameworkBasics.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    class MobileContext : DbContext
    {
        static MobileContext()
        {
            Database.SetInitializer<MobileContext>(new MyContextInitializer());
        }

        public MobileContext()
            : base("DefaultConnection")
        { }
        public DbSet<Phone> Phones { get; set; }
    }

    class MyContextInitializer : DropCreateDatabaseAlways<MobileContext>
    {
        protected override void Seed(MobileContext context)
        {
            Phone p1 = new Phone { Name="Asus Zephone 5", Price=80000 };
            Phone p2 = new Phone { Name = "Asus Zephone 6", Price = 100000 };

            context.Phones.Add(p1);
            context.Phones.Add(p2);
            context.SaveChanges();
        }
    }
}