using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
            .Property(c => c.Id)
            .ValueGeneratedNever();
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Anders Samuelsson", City = "Gothenburg", PhoneNumber = "004631152659", Id = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Jens Rassmusen", City = "Copenhagen", PhoneNumber = "0047454862", Id = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Ole Bramserud", City = "Oslo", PhoneNumber = "0045786525", Id = 3 });

            

        }


    }
}
