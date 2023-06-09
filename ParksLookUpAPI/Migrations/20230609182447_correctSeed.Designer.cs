﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParksLookUpAPI.Models;

#nullable disable

namespace ParksLookUpAPI.Migrations
{
    [DbContext(typeof(ParksLookUpAPIContext))]
    [Migration("20230609182447_correctSeed")]
    partial class correctSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParksLookUpAPI.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Features = "the Narrows",
                            Name = "Zion",
                            Rating = 8,
                            State = "Utah"
                        },
                        new
                        {
                            ParkId = 2,
                            Features = "The Sun Road",
                            Name = "Glacier",
                            Rating = 9,
                            State = "Montana"
                        },
                        new
                        {
                            ParkId = 3,
                            Features = "Half Dome",
                            Name = "Yosemite",
                            Rating = 7,
                            State = "California"
                        },
                        new
                        {
                            ParkId = 4,
                            Features = "Jenny Lake",
                            Name = "The Grand Tetons",
                            Rating = 7,
                            State = "Wyoming"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
