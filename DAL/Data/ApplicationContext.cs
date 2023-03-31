using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection.Metadata;

namespace DAL.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Forum> Forums { get; set; } = null!;
        public DbSet<ForumMessage> ForumMessages { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["TestConnectionString"]
            //     .ConnectionString;
            //optionsBuilder.UseSqlServer(connectionString);


            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=prot1;Database=laba3hunter;Trusted_Connection=True;");

            optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ForumMessage>()
                .Property(b => b.IsEditing)
                .HasDefaultValue(false);
            modelBuilder.Entity<ForumMessage>()
                .Property(b => b.DateOfDispath)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
