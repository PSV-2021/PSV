﻿// <auto-generated />
using System;
using Hospital.SharedModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20211117211807_doctorMigration")]
    partial class doctorMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Model.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<int>("AvailableDaysOff")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("SalaryInRsd")
                        .HasColumnType("integer");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<int>("SpecialityId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Bulevar Oslobodjenja 4",
                            AvailableDaysOff = 20,
                            DateOfBirth = new DateTime(1998, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "milan@gmail.com",
                            Jmbg = "3009998805137",
                            Name = "Milan",
                            Password = "02145",
                            PhoneNumber = "0641664608",
                            SalaryInRsd = 200000,
                            Sex = 0,
                            SpecialityId = 1,
                            Surname = "Popovic",
                            Type = 2,
                            Username = "miki56"
                        });
                });

            modelBuilder.Entity("Model.Ingridient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Ingridients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Panclav"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Penicilin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Panadol"
                        });
                });

            modelBuilder.Entity("Model.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Speciality");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "general"
                        });
                });

            modelBuilder.Entity("Model.UserFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeWritten")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("canPublish")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("UserFeedbacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Good!",
                            Name = "Mika Mikic",
                            TimeWritten = new DateTime(2021, 11, 17, 22, 18, 6, 615, DateTimeKind.Local).AddTicks(2116),
                            canPublish = false
                        },
                        new
                        {
                            Id = 2,
                            Content = "I didn't like it.",
                            Name = "Anonymus",
                            TimeWritten = new DateTime(2021, 11, 17, 22, 18, 6, 618, DateTimeKind.Local).AddTicks(2459),
                            canPublish = true
                        },
                        new
                        {
                            Id = 3,
                            Content = "Super service!",
                            Name = "Sara Saric",
                            TimeWritten = new DateTime(2021, 11, 17, 22, 18, 6, 618, DateTimeKind.Local).AddTicks(2531),
                            canPublish = true
                        });
                });

            modelBuilder.Entity("Model.VacationDays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("VacationDays");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Model.WorkingHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BeginningDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Shift")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("WorkingHours");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BeginningDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Shift = 0
                        });
                });

            modelBuilder.Entity("Model.Doctor", b =>
                {
                    b.HasOne("Model.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("Model.VacationDays", b =>
                {
                    b.HasOne("Model.Doctor", null)
                        .WithMany("VacationDays")
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("Model.WorkingHours", b =>
                {
                    b.HasOne("Model.Doctor", null)
                        .WithMany("WorkingSchedule")
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("Model.Doctor", b =>
                {
                    b.Navigation("VacationDays");

                    b.Navigation("WorkingSchedule");
                });
#pragma warning restore 612, 618
        }
    }
}
