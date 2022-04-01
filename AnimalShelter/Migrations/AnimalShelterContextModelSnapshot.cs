﻿// <auto-generated />
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalShelter.Migrations
{
    [DbContext(typeof(AnimalShelterContext))]
    partial class AnimalShelterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AnimalShelter.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            Age = 2,
                            Gender = "Female",
                            Name = "Link",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalId = 2,
                            Age = 2,
                            Gender = "Female",
                            Name = "Zelda",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalId = 3,
                            Age = 3,
                            Gender = "Male",
                            Name = "Ganon",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalId = 4,
                            Age = 4,
                            Gender = "Female",
                            Name = "Merry",
                            Type = "Dog"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
