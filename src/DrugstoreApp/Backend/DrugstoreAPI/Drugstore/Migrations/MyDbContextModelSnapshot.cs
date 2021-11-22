﻿// <auto-generated />
using System;
using Drugstore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Drugstore.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Drugstore.Models.DrugstoreOffer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("DrugstoreName")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DrugstoreOffers");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Content = "Content",
                            DrugstoreName = "Apotekica",
                            EndDate = new DateTime(2021, 11, 19, 20, 52, 11, 273, DateTimeKind.Local).AddTicks(1562),
                            StartDate = new DateTime(2021, 11, 19, 20, 52, 11, 268, DateTimeKind.Local).AddTicks(8232),
                            Title = "title"
                        });
                });

            modelBuilder.Entity("Drugstore.Models.Feedback", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("HospitalName")
                        .HasColumnType("text");

                    b.Property<string>("Response")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            Id = "aaa",
                            Content = "Lenka vrati zeton",
                            HospitalName = "Health",
                            Response = ""
                        },
                        new
                        {
                            Id = "bbb",
                            Content = "normalno",
                            HospitalName = "Ime bolnice 223",
                            Response = ""
                        },
                        new
                        {
                            Id = "ccc",
                            Content = "bla bla",
                            HospitalName = "Ime bolnice 224",
                            Response = ""
                        });
                });

            modelBuilder.Entity("Drugstore.Models.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApiKey")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApiKey = "DrugStoreSecretKey",
                            Name = "Health",
                            Url = "http://localhost:5000"
                        });
                });

            modelBuilder.Entity("Drugstore.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Supply")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brufen",
                            Price = 150.0,
                            Supply = 150
                        },
                        new
                        {
                            Id = 2,
                            Name = "Paracetamol",
                            Price = 150.0,
                            Supply = 10
                        },
                        new
                        {
                            Id = 3,
                            Name = "Palitreks",
                            Price = 150.0,
                            Supply = 30
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
