﻿// <auto-generated />
using System;
using System.Collections.Generic;
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

            modelBuilder.Entity("Drugstore.Models.DrugTender", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("TenderEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TenderInfo")
                        .HasColumnType("text");

                    b.Property<bool>("isFinished")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("DrugTenders");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            TenderEnd = new DateTime(2021, 12, 29, 13, 47, 35, 275, DateTimeKind.Local).AddTicks(1941),
                            TenderInfo = "Brufen - 150, Palitreks - 100, Andol - 40",
                            isFinished = true
                        },
                        new
                        {
                            Id = "2",
                            TenderEnd = new DateTime(2022, 2, 2, 13, 47, 35, 275, DateTimeKind.Local).AddTicks(3194),
                            TenderInfo = "Brufen - 120, Palitreks - 90, Andol - 50",
                            isFinished = false
                        },
                        new
                        {
                            Id = "3",
                            TenderEnd = new DateTime(2022, 1, 5, 13, 47, 35, 275, DateTimeKind.Local).AddTicks(3242),
                            TenderInfo = "Brufen - 2, Palitreks - 2, Andol - 2",
                            isFinished = true
                        },
                        new
                        {
                            Id = "4",
                            TenderEnd = new DateTime(2021, 12, 15, 13, 47, 35, 275, DateTimeKind.Local).AddTicks(3245),
                            TenderInfo = "Brufen - 10, Palitreks - 50, Andol - 35",
                            isFinished = true
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
                            EndDate = new DateTime(2022, 1, 12, 13, 47, 35, 274, DateTimeKind.Local).AddTicks(6870),
                            StartDate = new DateTime(2022, 1, 12, 13, 47, 35, 272, DateTimeKind.Local).AddTicks(8945),
                            Title = "title"
                        });
                });

            modelBuilder.Entity("Drugstore.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("EventName")
                        .HasColumnType("text");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("DrugstoreEvents", "DrugstoreEvents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventName = "Klik",
                            EventTime = new DateTime(2022, 1, 15, 16, 10, 42, 20, DateTimeKind.Local).AddTicks(7795)
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

                    b.Property<string>("Email")
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
                            Email = "crnimraz99@gmail.com",
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
                            Supply = 200,
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
                            Supply = 200,
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
                            Supply = 200,
                            Usage = "bla",
                            Weight = 100.0
                        },
                        new
                        {
                            Id = 4,
                            Manufacturer = "bla",
                            Name = "Andol",
                            Precautions = "bla",
                            Price = 150.0,
                            Reactions = "bla",
                            SideEffects = "bla",
                            Substances = "bla",
                            Supply = 200,
                            Usage = "bla",
                            Weight = 100.0
                        });
                });

            modelBuilder.Entity("Drugstore.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Posted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<List<string>>("Recipients")
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Aloaloalo",
                            Posted = new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Uzbuna"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Stigli su novi lekovi",
                            Posted = new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Novi lekovi"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Obavestenje o promeni cena",
                            Posted = new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Vazno obavestenje"
                        });
                });

            modelBuilder.Entity("Drugstore.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

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

            modelBuilder.Entity("Drugstore.Models.TenderOffer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("DrugstoreId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("TenderId")
                        .HasColumnType("text");

                    b.Property<string>("TenderOfferInfo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TenderOffers");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            DrugstoreId = 1,
                            IsAccepted = true,
                            IsActive = false,
                            Price = 5000,
                            TenderId = "1",
                            TenderOfferInfo = "Brufen - 100, Palitreks - 80, Andol - 40"
                        },
                        new
                        {
                            Id = "3",
                            DrugstoreId = 1,
                            IsAccepted = true,
                            IsActive = false,
                            Price = 500,
                            TenderId = "3",
                            TenderOfferInfo = "Brufen - 2, Palitreks - 2, Andol - 2"
                        },
                        new
                        {
                            Id = "7",
                            DrugstoreId = 1,
                            IsAccepted = false,
                            IsActive = false,
                            Price = 10000,
                            TenderId = "1",
                            TenderOfferInfo = "Brufen - 10, Palitreks - 80, Andol - 40"
                        },
                        new
                        {
                            Id = "4",
                            DrugstoreId = 1,
                            IsAccepted = false,
                            IsActive = true,
                            Price = 2900,
                            TenderId = "4",
                            TenderOfferInfo = "Brufen - 10, Palitreks - 50, Andol - 35"
                        });
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
