﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.DataBaseContext;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
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

            modelBuilder.Entity("Integration.Model.Drug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Supply")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brufen",
                            Supply = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Paracetamol",
                            Supply = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Palitreks",
                            Supply = 0
                        });
                });

            modelBuilder.Entity("Integration.Model.DrugConsumed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateConsumed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DrugsConsumed");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 98,
                            DateConsumed = new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Brufen"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 65,
                            DateConsumed = new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Palitrex"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 45,
                            DateConsumed = new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Amoksicilin"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 43,
                            DateConsumed = new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sinacilin"
                        },
                        new
                        {
                            Id = 5,
                            Amount = 67,
                            DateConsumed = new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andol"
                        },
                        new
                        {
                            Id = 6,
                            Amount = 65,
                            DateConsumed = new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panadol"
                        },
                        new
                        {
                            Id = 7,
                            Amount = 36,
                            DateConsumed = new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panklav"
                        },
                        new
                        {
                            Id = 8,
                            Amount = 76,
                            DateConsumed = new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Brufen"
                        },
                        new
                        {
                            Id = 9,
                            Amount = 56,
                            DateConsumed = new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Palitrex"
                        },
                        new
                        {
                            Id = 10,
                            Amount = 54,
                            DateConsumed = new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Amoksicilin"
                        },
                        new
                        {
                            Id = 11,
                            Amount = 34,
                            DateConsumed = new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sinacilin"
                        },
                        new
                        {
                            Id = 12,
                            Amount = 87,
                            DateConsumed = new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andol"
                        },
                        new
                        {
                            Id = 13,
                            Amount = 67,
                            DateConsumed = new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panadol"
                        },
                        new
                        {
                            Id = 14,
                            Amount = 33,
                            DateConsumed = new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panklav"
                        },
                        new
                        {
                            Id = 15,
                            Amount = 78,
                            DateConsumed = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Brufen"
                        },
                        new
                        {
                            Id = 16,
                            Amount = 66,
                            DateConsumed = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Palitrex"
                        },
                        new
                        {
                            Id = 17,
                            Amount = 48,
                            DateConsumed = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Amoksicilin"
                        },
                        new
                        {
                            Id = 18,
                            Amount = 44,
                            DateConsumed = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sinacilin"
                        },
                        new
                        {
                            Id = 19,
                            Amount = 56,
                            DateConsumed = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andol"
                        },
                        new
                        {
                            Id = 20,
                            Amount = 75,
                            DateConsumed = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panadol"
                        },
                        new
                        {
                            Id = 21,
                            Amount = 39,
                            DateConsumed = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panklav"
                        },
                        new
                        {
                            Id = 22,
                            Amount = 105,
                            DateConsumed = new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Brufen"
                        },
                        new
                        {
                            Id = 23,
                            Amount = 66,
                            DateConsumed = new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Palitrex"
                        },
                        new
                        {
                            Id = 24,
                            Amount = 42,
                            DateConsumed = new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Amoksicilin"
                        },
                        new
                        {
                            Id = 25,
                            Amount = 54,
                            DateConsumed = new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sinacilin"
                        },
                        new
                        {
                            Id = 26,
                            Amount = 77,
                            DateConsumed = new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andol"
                        },
                        new
                        {
                            Id = 27,
                            Amount = 64,
                            DateConsumed = new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panadol"
                        },
                        new
                        {
                            Id = 28,
                            Amount = 38,
                            DateConsumed = new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panklav"
                        },
                        new
                        {
                            Id = 29,
                            Amount = 78,
                            DateConsumed = new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Brufen"
                        },
                        new
                        {
                            Id = 30,
                            Amount = 66,
                            DateConsumed = new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Palitrex"
                        },
                        new
                        {
                            Id = 31,
                            Amount = 87,
                            DateConsumed = new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Amoksicilin"
                        },
                        new
                        {
                            Id = 32,
                            Amount = 56,
                            DateConsumed = new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sinacilin"
                        },
                        new
                        {
                            Id = 33,
                            Amount = 45,
                            DateConsumed = new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andol"
                        },
                        new
                        {
                            Id = 34,
                            Amount = 56,
                            DateConsumed = new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panadol"
                        },
                        new
                        {
                            Id = 35,
                            Amount = 76,
                            DateConsumed = new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panklav"
                        },
                        new
                        {
                            Id = 36,
                            Amount = 93,
                            DateConsumed = new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Brufen"
                        },
                        new
                        {
                            Id = 37,
                            Amount = 62,
                            DateConsumed = new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Palitrex"
                        },
                        new
                        {
                            Id = 38,
                            Amount = 49,
                            DateConsumed = new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Amoksicilin"
                        },
                        new
                        {
                            Id = 39,
                            Amount = 46,
                            DateConsumed = new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sinacilin"
                        },
                        new
                        {
                            Id = 40,
                            Amount = 72,
                            DateConsumed = new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andol"
                        },
                        new
                        {
                            Id = 41,
                            Amount = 60,
                            DateConsumed = new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panadol"
                        },
                        new
                        {
                            Id = 42,
                            Amount = 34,
                            DateConsumed = new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panklav"
                        },
                        new
                        {
                            Id = 43,
                            Amount = 97,
                            DateConsumed = new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Brufen"
                        },
                        new
                        {
                            Id = 44,
                            Amount = 62,
                            DateConsumed = new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Palitrex"
                        },
                        new
                        {
                            Id = 45,
                            Amount = 39,
                            DateConsumed = new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Amoksicilin"
                        },
                        new
                        {
                            Id = 46,
                            Amount = 46,
                            DateConsumed = new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sinacilin"
                        },
                        new
                        {
                            Id = 47,
                            Amount = 77,
                            DateConsumed = new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andol"
                        },
                        new
                        {
                            Id = 48,
                            Amount = 60,
                            DateConsumed = new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panadol"
                        },
                        new
                        {
                            Id = 49,
                            Amount = 38,
                            DateConsumed = new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Panklav"
                        });
                });

            modelBuilder.Entity("Integration.Model.Drugstore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("ApiKey")
                        .HasColumnType("text");

                    b.Property<string>("Base64Image")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<bool>("gRPC")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Drugstores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Tolstojeva 3",
                            ApiKey = "DrugStoreSecretKey",
                            City = "Novi Sad",
                            Email = "apoteka1@gmail.com",
                            Name = "Apoteka prva",
                            Url = "http://localhost:5001",
                            gRPC = true
                        },
                        new
                        {
                            Id = 2,
                            Address = "Balzakova 3",
                            ApiKey = "wnjgjowenfweo",
                            City = "Novi Sad",
                            Email = "apoteka2@gmail.com",
                            Name = "Apoteka druga",
                            Url = "http://localhost:5002",
                            gRPC = false
                        },
                        new
                        {
                            Id = 3,
                            Address = "Puskinova 3",
                            ApiKey = "wuhguiwoehfuhw",
                            City = "Beograd",
                            Email = "apoteka3@gmail.com",
                            Name = "Apoteka treca",
                            Url = "http://localhost:5003",
                            gRPC = false
                        });
                });

            modelBuilder.Entity("Integration.Model.DrugstoreFeedback", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("DrugstoreId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RecievedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Response")
                        .HasColumnType("text");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("DrugstoreFeedbacks");

                    b.HasData(
                        new
                        {
                            Id = "aaa",
                            Content = "Nije mi se svidela usluga",
                            DrugstoreId = 1,
                            RecievedTime = new DateTime(2021, 12, 12, 20, 25, 49, 142, DateTimeKind.Local).AddTicks(5313),
                            Response = "Nemoj da lazes!",
                            SentTime = new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(2014)
                        },
                        new
                        {
                            Id = "bbb",
                            Content = "Svidjela usluga",
                            DrugstoreId = 2,
                            RecievedTime = new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(3937),
                            Response = "Nemoj da lazes!",
                            SentTime = new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(3993)
                        },
                        new
                        {
                            Id = "ccc",
                            Content = "Nije mi se svidela usluga",
                            DrugstoreId = 3,
                            RecievedTime = new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(4040),
                            Response = "Nemoj da lazes!",
                            SentTime = new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(4047)
                        });
                });

            modelBuilder.Entity("Integration.Model.DrugstoreOffer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("DrugstoreName")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

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
                            EndDate = new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(4837),
                            IsPublished = false,
                            StartDate = new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(4827),
                            Title = "title"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
