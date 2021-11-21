﻿// <auto-generated />
using System;
using Hospital.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20211121095513_newMigration4")]
    partial class newMigration4
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

                    b.Property<int>("NumberOfPatients")
                        .HasColumnType("integer");

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
                            NumberOfPatients = 0,
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

                    b.Property<int?>("MedicalRecordId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

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

            modelBuilder.Entity("Model.MedicalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HealthInsuranceNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MedicalRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HealthInsuranceNumber = "1ab"
                        });
                });

            modelBuilder.Entity("Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<int>("BloodType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("text");

                    b.Property<string>("FathersName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<int>("MedicalRecordId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Bulevar Oslobodjenja 8",
                            BloodType = 1,
                            DateOfBirth = new DateTime(1998, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 1,
                            Email = "marko@gmail.com",
                            FathersName = "Petar",
                            IsActive = true,
                            IsBlocked = false,
                            Jmbg = "3009998805138",
                            MedicalRecordId = 1,
                            Name = "Marko",
                            Password = "miki985",
                            PhoneNumber = "0641664608",
                            Sex = 0,
                            Surname = "Markovic",
                            Type = 3,
                            Username = "miki98"
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
                            TimeWritten = new DateTime(2021, 11, 21, 10, 55, 12, 823, DateTimeKind.Local).AddTicks(1784),
                            canPublish = false
                        },
                        new
                        {
                            Id = 2,
                            Content = "I didn't like it.",
                            Name = "Anonymus",
                            TimeWritten = new DateTime(2021, 11, 21, 10, 55, 12, 825, DateTimeKind.Local).AddTicks(9623),
                            canPublish = true
                        },
                        new
                        {
                            Id = 3,
                            Content = "Super service!",
                            Name = "Sara Saric",
                            TimeWritten = new DateTime(2021, 11, 21, 10, 55, 12, 825, DateTimeKind.Local).AddTicks(9740),
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

            modelBuilder.Entity("Model.Ingridient", b =>
                {
                    b.HasOne("Model.MedicalRecord", null)
                        .WithMany("Allergen")
                        .HasForeignKey("MedicalRecordId");
                });

            modelBuilder.Entity("Model.Patient", b =>
                {
                    b.HasOne("Model.Doctor", "ChosenDoctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.MedicalRecord", "MedicalRecord")
                        .WithMany()
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChosenDoctor");

                    b.Navigation("MedicalRecord");
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

            modelBuilder.Entity("Model.MedicalRecord", b =>
                {
                    b.Navigation("Allergen");
                });
#pragma warning restore 612, 618
        }
    }
}
