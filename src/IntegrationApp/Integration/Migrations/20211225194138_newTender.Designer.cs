﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.DataBaseContext;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20211225194138_newTender")]
    partial class newTender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

                    b.Property<string>("ApiKey")
                        .HasColumnType("text");

                    b.Property<string>("Base64Image")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
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
                            ApiKey = "DrugStoreSecretKey",
                            Name = "Apoteka prva",
                            Url = "http://localhost:5001",
                            gRPC = true
                        },
                        new
                        {
                            Id = 2,
                            ApiKey = "nestorandom",
                            Name = "Apoteka druga",
                            Url = "http://localhost:6001",
                            gRPC = true
                        },
                        new
                        {
                            Id = 3,
                            ApiKey = "gasic",
                            Name = "Apoteka treca",
                            Url = "http://localhost:7001",
                            gRPC = true
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
                });

            modelBuilder.Entity("Integration.Model.DrugstoreOffer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("DrugstoreName")
                        .HasColumnType("text");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

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
                            IsPublished = false,
                            Title = "title"
                        });
                });

            modelBuilder.Entity("Integration.Tendering.Model.DrugTender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                            Id = 1,
                            TenderEnd = new DateTime(2021, 12, 18, 20, 41, 37, 543, DateTimeKind.Local).AddTicks(6606),
                            TenderInfo = "Brufen - 150, Palitreks - 100, Andol - 40",
                            isFinished = true
                        },
                        new
                        {
                            Id = 2,
                            TenderEnd = new DateTime(2022, 1, 15, 20, 41, 37, 548, DateTimeKind.Local).AddTicks(1532),
                            TenderInfo = "Brufen - 120, Palitreks - 90, Andol - 50",
                            isFinished = false
                        });
                });

            modelBuilder.Entity("Integration.Tendering.Model.TenderOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DrugstoreId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("TenderId")
                        .HasColumnType("integer");

                    b.Property<string>("TenderOfferInfo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TenderOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DrugstoreId = 1,
                            IsAccepted = false,
                            IsActive = true,
                            Price = 5000,
                            TenderId = 2,
                            TenderOfferInfo = "Brufen - 100, Palitreks - 80, Andol - 40"
                        },
                        new
                        {
                            Id = 2,
                            DrugstoreId = 2,
                            IsAccepted = false,
                            IsActive = true,
                            Price = 5900,
                            TenderId = 2,
                            TenderOfferInfo = "Brufen - 120, Palitreks - 50, Andol - 35"
                        });
                });

            modelBuilder.Entity("Integration.Model.Drugstore", b =>
                {
                    b.OwnsOne("Integration.Drugstore_Interaction.Model.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("DrugstoreId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .HasColumnType("text");

                            b1.HasKey("DrugstoreId");

                            b1.ToTable("Drugstores");

                            b1.WithOwner()
                                .HasForeignKey("DrugstoreId");

                            b1.HasData(
                                new
                                {
                                    DrugstoreId = 1,
                                    City = "Novi Sad",
                                    Country = "Srbija",
                                    Street = "Tolstojeva 5"
                                },
                                new
                                {
                                    DrugstoreId = 2,
                                    City = "Beograd",
                                    Country = "Srbija",
                                    Street = "Balzakova 31"
                                },
                                new
                                {
                                    DrugstoreId = 3,
                                    City = "Subotica",
                                    Country = "Srbija",
                                    Street = "Cara Dusana 56"
                                });
                        });

                    b.OwnsOne("Integration.Drugstore_Interaction.Model.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("DrugstoreId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("EmailValue")
                                .HasColumnType("text");

                            b1.HasKey("DrugstoreId");

                            b1.ToTable("Drugstores");

                            b1.WithOwner()
                                .HasForeignKey("DrugstoreId");

                            b1.HasData(
                                new
                                {
                                    DrugstoreId = 1,
                                    EmailValue = "apotekaprva@gmail.com"
                                },
                                new
                                {
                                    DrugstoreId = 2,
                                    EmailValue = "drugimeil@gmail.com"
                                },
                                new
                                {
                                    DrugstoreId = 3,
                                    EmailValue = "trecimejl@gmail.com"
                                });
                        });

                    b.Navigation("Address");

                    b.Navigation("Email");
                });

            modelBuilder.Entity("Integration.Model.DrugstoreOffer", b =>
                {
                    b.OwnsOne("Integration.Model.DateRange", "TimeRange", b1 =>
                        {
                            b1.Property<string>("DrugstoreOfferId")
                                .HasColumnType("text");

                            b1.HasKey("DrugstoreOfferId");

                            b1.ToTable("DrugstoreOffers");

                            b1.WithOwner()
                                .HasForeignKey("DrugstoreOfferId");

                            b1.HasData(
                                new
                                {
                                    DrugstoreOfferId = "1"
                                });
                        });

                    b.Navigation("TimeRange");
                });
#pragma warning restore 612, 618
        }
    }
}
