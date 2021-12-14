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

            modelBuilder.Entity("Drugstore.Models.DrugSpecification", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("DrugSpecifications");

                    b.HasData(
                        new
                        {
                            Name = "Brufen",
                            Text = "Ovde ide tekst specifikacije za Brufen"
                        },
                        new
                        {
                            Name = "Paracetamol",
                            Text = "Ovde ide tekst specifikacije za Paracetamol"
                        },
                        new
                        {
                            Name = "Palitreks",
                            Text = "Ovde ide tekst specifikacije za Palitreks"
                        });
                });

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
                            EndDate = new DateTime(2021, 12, 14, 3, 58, 13, 378, DateTimeKind.Local).AddTicks(5813),
                            StartDate = new DateTime(2021, 12, 14, 3, 58, 13, 371, DateTimeKind.Local).AddTicks(9311),
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

                    b.Property<string>("Manufacturer")
                        .HasColumnType("text");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("integer");

                    b.Property<string>("MedicineImage")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Precautions")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Reactions")
                        .HasColumnType("text");

                    b.Property<string>("SideEffects")
                        .HasColumnType("text");

                    b.Property<string>("Substances")
                        .HasColumnType("text");

                    b.Property<int>("Supply")
                        .HasColumnType("integer");

                    b.Property<string>("Usage")
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.ToTable("Medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Manufacturer = "bla",
                            Name = "Brufen",
                            Precautions = "bla",
                            Price = 150.0,
                            Reactions = "bla",
                            SideEffects = "bla",
                            Substances = "bla",
                            Supply = 150,
                            Usage = "bla",
                            Weight = 100.0
                        },
                        new
                        {
                            Id = 2,
                            Manufacturer = "bla",
                            Name = "Paracetamol",
                            Precautions = "bla",
                            Price = 150.0,
                            Reactions = "bla",
                            SideEffects = "bla",
                            Substances = "bla",
                            Supply = 10,
                            Usage = "bla",
                            Weight = 100.0
                        },
                        new
                        {
                            Id = 3,
                            Manufacturer = "bla",
                            Name = "Palitreks",
                            Precautions = "bla",
                            Price = 150.0,
                            Reactions = "bla",
                            SideEffects = "bla",
                            Substances = "bla",
                            Supply = 30,
                            Usage = "bla",
                            Weight = 100.0
                        });
                });

            modelBuilder.Entity("Drugstore.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Delivered")
                        .HasColumnType("boolean");

                    b.Property<int>("OrderType")
                        .HasColumnType("integer");

                    b.Property<bool>("PickedUp")
                        .HasColumnType("boolean");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Drugstore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Drugstore.Models.Customer", b =>
                {
                    b.HasBaseType("Drugstore.Models.User");

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("Customer_Name");

                    b.HasDiscriminator().HasValue("Customer");

                    b.HasData(
                        new
                        {
                            UserId = 5,
                            Password = "kupac",
                            Role = "Customer",
                            Username = "kupac",
                            Adress = "Adresa kupca 123",
                            Name = "Kupac"
                        });
                });

            modelBuilder.Entity("Drugstore.Models.Pharmacist", b =>
                {
                    b.HasBaseType("Drugstore.Models.User");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Pharmacist");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "farmaceut",
                            Role = "Pharmacist",
                            Username = "farmaceut",
                            Name = "Farmaceut"
                        });
                });

            modelBuilder.Entity("Drugstore.Models.Medicine", b =>
                {
                    b.HasOne("Drugstore.Models.Medicine", null)
                        .WithMany("CompatibleMedicines")
                        .HasForeignKey("MedicineId");
                });

            modelBuilder.Entity("Drugstore.Models.Medicine", b =>
                {
                    b.Navigation("CompatibleMedicines");
                });
#pragma warning restore 612, 618
        }
    }
}
