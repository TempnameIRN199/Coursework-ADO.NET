using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Coursework.Migrations;

namespace Coursework.Database
{
    public class NintendoContext : DbContext
    {
        public NintendoContext() : base("NintendoContext")
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<NintendoContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
