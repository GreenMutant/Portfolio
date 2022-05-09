﻿using System;
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
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
            .Property(c => c.Id)
            .ValueGeneratedNever();

            modelBuilder.Entity<City>().HasData(new City { CityName = "Gothenburg", CityId = 1, CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Copenhagen", CityId = 2, CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Oslo", CityId = 3, CountryId = 3 });

            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Sweden", CountryId = 1 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Denmark", CountryId = 2 });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Norway", CountryId = 3 });

            modelBuilder.Entity<Person>().HasData(new Person { Name = "Anders Samuelsson", PhoneNumber = "004631152659", Id = 1, CityId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Jens Rassmusen", PhoneNumber = "0047454862", Id = 2, CityId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Ole Bramserud", PhoneNumber = "0045786525", Id = 3, CityId = 3 });

            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "Swedish", LanguageId = 1 });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "Danish", LanguageId = 2 });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "Norwegian", LanguageId = 3 });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 1, Id = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 2, Id = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { LanguageId = 3, Id = 3 });

           
            modelBuilder.Entity<City>()
                .HasMany(co => co.People)
                .WithOne(c => c.City);

            modelBuilder.Entity<Country>()
                .HasMany(co => co.Cities)
                .WithOne(c => c.Country);


            modelBuilder.Entity<PersonLanguage>()
                .HasOne(co => co.Language)
                .WithMany(c => c.PersonLanguages)
                .HasForeignKey(c => c.LanguageId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(co => co.Person)
                .WithMany(c => c.PersonLanguages)
                .HasForeignKey(c => c.Id);

        }


    }
}