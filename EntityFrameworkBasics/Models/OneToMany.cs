using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EntityFrameworkBasics.Models
{
    // Связь один ко многим

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; } // eager loading
    }
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } // название команды

        public virtual ICollection<Player> Players { get; set; } // lazy loading
        public Team()
        {
            Players = new List<Player>();
        }
    }
    public class SoccerContext : DbContext
    {
        public SoccerContext()
            : base("SoccerContext")
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}