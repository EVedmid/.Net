using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class NewsContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Post> Posts { get; set; }

        public NewsContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost; Port = 5432; Database = Lab4; Username = postgres; Password = 1111");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasData(
                new Guest { Login = "admin", PasswordHash = "admin", GuestRole = "Manager"});
        }
    }
}
