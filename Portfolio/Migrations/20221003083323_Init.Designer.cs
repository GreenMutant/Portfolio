﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Data;

namespace Portfolio.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221003083323_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Portfolio.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Portfolio.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("CountryId");

                    b.HasIndex("PersonId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Portfolio.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Gothenburg",
                            Name = "Anders Samuelsson",
                            PhoneNumber = "004631152659"
                        },
                        new
                        {
                            Id = 2,
                            City = "Copenhagen",
                            Name = "Jens Rassmusen",
                            PhoneNumber = "0047454862"
                        },
                        new
                        {
                            Id = 3,
                            City = "Oslo",
                            Name = "Ole Bramserud",
                            PhoneNumber = "0045786525"
                        });
                });

            modelBuilder.Entity("Portfolio.Models.City", b =>
                {
                    b.HasOne("Portfolio.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portfolio.Models.Country", b =>
                {
                    b.HasOne("Portfolio.Models.Person", null)
                        .WithMany("Languages")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Portfolio.Models.Person", b =>
                {
                    b.HasOne("Portfolio.Models.City", null)
                        .WithMany("People")
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}
