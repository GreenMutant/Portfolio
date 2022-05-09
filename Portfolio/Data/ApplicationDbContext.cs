﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Portfolio.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace Portfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
                                        ApplicationUserRole, 
                                        IdentityUserLogin<string>,
                                        IdentityRoleClaim<string>, 
                                        IdentityUserToken<string>> {
        public DbSet<Person> People { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.City)
                .WithMany(c => c.People)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<City>()
                .HasOne(p => p.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonLanguage>(personLanguage =>
            {
                personLanguage.HasKey(pl => new { pl.PersonId, pl.LanguageId });

                personLanguage.HasOne(pl => pl.Person)
                    .WithMany(p => p.PersonLanguages)
                    .HasForeignKey(pl => pl.PersonId);

                personLanguage.HasOne(pl => pl.Language)
                    .WithMany(l => l.PersonLanguages)
                    .HasForeignKey(pl => pl.LanguageId);
            });

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId);
            });

            modelBuilder.Entity<Country>().HasData(new Country[] {
                new Country { Id = 1, Name = "Sweden" },
                new Country { Id = 2, Name = "Danmark" },
                new Country { Id = 3, Name = "Norway" }
                
            });

            modelBuilder.Entity<City>().HasData(new City[] {
                new City { Id = 1, CountryId= 1, Name = "Gothenburg" },
                new City { Id = 2, CountryId= 2, Name = "Copenhagen" },
                new City { Id = 3, CountryId= 3, Name = "Oslo" }
                
            });

            modelBuilder.Entity<Person>().HasData(new Person[] {
                new Person { Id = 1,  CityId = 1, PhoneNumber = "+46-31-152659", Name = "Anders Samuelsson" },
                new Person { Id = 2,  CityId = 2, PhoneNumber = "+47-2-7454862", Name = "Jens Rassmusen" },
                new Person { Id = 3,  CityId = 3, PhoneNumber = "+45-33-786525", Name = "Ole Bramserud" }
               
            });

            modelBuilder.Entity<Language>().HasData(new Language[] {
                new Language { Id = 1, Name = "Swedish" },
                new Language { Id = 2, Name = "Danish" },
                new Language { Id = 3, Name = "Norwegian" }
            });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage[] {
                 new PersonLanguage {  PersonId = 1, LanguageId = 1 },
                 new PersonLanguage {  PersonId = 2, LanguageId = 2 },
                 new PersonLanguage {  PersonId = 3, LanguageId = 3 }
                 
            });

            string roleID = Guid.NewGuid().ToString();
            string userRoleID = Guid.NewGuid().ToString();
            string userID = Guid.NewGuid().ToString();

            modelBuilder.Entity<ApplicationRole>().HasData(new IdentityRole
            {
                Id = roleID,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<ApplicationRole>().HasData(new IdentityRole()
            {
                Id = userRoleID,
                Name = "User",
                NormalizedName = "USER"
            });

            modelBuilder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole()
            {
                RoleId = roleID,
                UserId = userID
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = userID,
                Email = "admin@fakemail.net",
                NormalizedEmail = "ADMIN@FAKEMAIL.NET",
                UserName = "admin@fakemail.net",
                NormalizedUserName = "ADMIN@FAKEMAIL.NET",
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateTime(1983, 11, 15),
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "password")
            });
        }
    }
}