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

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Drugstores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Tolstojeva 3, Novi Sad",
                            ApiKey = "aaabbbccc",
                            Email = "apoteka1@gmail.com",
                            Name = "Apoteka prva",
                            Url = "http://localhost:5001"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Balzakova 3, Novi Sad",
                            ApiKey = "wnjgjowenfweo",
                            Email = "apoteka2@gmail.com",
                            Name = "Apoteka druga",
                            Url = "http://localhost:5002"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Puskinova 3, Novi Sad",
                            ApiKey = "wuhguiwoehfuhw",
                            Email = "apoteka3@gmail.com",
                            Name = "Apoteka treca",
                            Url = "http://localhost:5003"
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
                            RecievedTime = new DateTime(2021, 11, 7, 22, 58, 9, 235, DateTimeKind.Local).AddTicks(9809),
                            Response = "Nemoj da lazes!",
                            SentTime = new DateTime(2021, 11, 7, 22, 58, 9, 240, DateTimeKind.Local).AddTicks(9213)
                        },
                        new
                        {
                            Id = "bbb",
                            Content = "Svidjela usluga",
                            DrugstoreId = 2,
                            RecievedTime = new DateTime(2021, 11, 7, 22, 58, 9, 241, DateTimeKind.Local).AddTicks(619),
                            Response = "Nemoj da lazes!",
                            SentTime = new DateTime(2021, 11, 7, 22, 58, 9, 241, DateTimeKind.Local).AddTicks(705)
                        },
                        new
                        {
                            Id = "ccc",
                            Content = "Nije mi se svidela usluga",
                            DrugstoreId = 3,
                            RecievedTime = new DateTime(2021, 11, 7, 22, 58, 9, 241, DateTimeKind.Local).AddTicks(734),
                            Response = "Nemoj da lazes!",
                            SentTime = new DateTime(2021, 11, 7, 22, 58, 9, 241, DateTimeKind.Local).AddTicks(742)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
