using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

// Связь один-к-одному

namespace EntityFrameworkBasics.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UserProfile Profile { get; set; }
    }



    // Чтобы установить связь одни к одному, у подчиненного класса устанавливается свойство идентификатора,
    // которое называется также, как и идентификатор в основном классе.
    public class UserProfile
    {
        [Key] // показывает, то это первичный ключ
        [ForeignKey("User")] // показывает, что это также и внешний ключ
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public User User { get; set; }
    }

    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }

}