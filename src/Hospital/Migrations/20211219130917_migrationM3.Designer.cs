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
    [Migration("20211219130917_migrationM3")]
    partial class migrationM3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Hospital.MedicalRecords.Model.Allergen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Allergens");
                });

            modelBuilder.Entity("Hospital.MedicalRecords.Model.AnsweredQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("QuestionType")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("SurveyId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AnsweredQuestion");
                });

            modelBuilder.Entity("Hospital.MedicalRecords.Model.Ingridient", b =>
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

            modelBuilder.Entity("Hospital.MedicalRecords.Model.MedicalRecord", b =>
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
                        },
                        new
                        {
                            Id = 2,
                            HealthInsuranceNumber = "2ab"
                        });
                });

            modelBuilder.Entity("Hospital.MedicalRecords.Model.Patient", b =>
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

                    b.Property<string>("FathersName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
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

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

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
                            Jmbg = "3009998805138",
                            MedicalRecordId = 1,
                            Name = "Marko",
                            Password = "miki985",
                            PhoneNumber = "0641664608",
                            Sex = 0,
                            Surname = "Markovic",
                            Type = 0,
                            Username = "miki98"
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Kisacka 5",
                            BloodType = 0,
                            DateOfBirth = new DateTime(1997, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 1,
                            Email = "milica@gmail.com",
                            FathersName = "Nenad",
                            IsActive = true,
                            Jmbg = "3009998805137",
                            MedicalRecordId = 2,
                            Name = "Milica",
                            Password = "mici789",
                            PhoneNumber = "065245987",
                            Sex = 1,
                            Surname = "Mikic",
                            Type = 0,
                            Username = "mici97"
                        });
                });

            modelBuilder.Entity("Hospital.MedicalRecords.Model.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DrugName")
                        .HasColumnType("text");

                    b.Property<DateTime>("IssuedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PatientName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Random opis nekog leka",
                            DrugName = "Palitrex",
                            IssuedTime = new DateTime(2021, 12, 19, 14, 9, 14, 875, DateTimeKind.Local).AddTicks(386),
                            PatientName = "Zoran Zoranic"
                        });
                });

            modelBuilder.Entity("Hospital.MedicalRecords.Model.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("Hospital.MedicalRecords.Model.SurveyQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("QuestionType")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SurveyQuestion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuestionType = 0,
                            Rating = 0,
                            Text = "How satisfied are you with the work of your doctor?"
                        },
                        new
                        {
                            Id = 2,
                            QuestionType = 0,
                            Rating = 0,
                            Text = "How satisfied were you with the time that your doctor spent with you?"
                        },
                        new
                        {
                            Id = 3,
                            QuestionType = 0,
                            Rating = 0,
                            Text = "During this hospital stay, did doctor treat you with courtesy and respect?"
                        },
                        new
                        {
                            Id = 4,
                            QuestionType = 0,
                            Rating = 0,
                            Text = "During this hospital stay, did doctor listen carefully to you?"
                        },
                        new
                        {
                            Id = 5,
                            QuestionType = 0,
                            Rating = 0,
                            Text = "During this hospital stay, did doctor explain things in a way you could understand?"
                        },
                        new
                        {
                            Id = 6,
                            QuestionType = 1,
                            Rating = 0,
                            Text = "During this hospital stay, did nurses treat you with courtesy and respect?"
                        },
                        new
                        {
                            Id = 7,
                            QuestionType = 1,
                            Rating = 0,
                            Text = "During this hospital stay, did nurses listen carefully to you?"
                        },
                        new
                        {
                            Id = 8,
                            QuestionType = 1,
                            Rating = 0,
                            Text = "During this hospital stay, did nurses explain things in a way you could understand?"
                        },
                        new
                        {
                            Id = 9,
                            QuestionType = 2,
                            Rating = 0,
                            Text = "How easy was it to schedule an appointment with our hospital?"
                        },
                        new
                        {
                            Id = 10,
                            QuestionType = 2,
                            Rating = 0,
                            Text = "How satisfied are you with the cleanliness and appearance of our hospital?"
                        },
                        new
                        {
                            Id = 11,
                            QuestionType = 2,
                            Rating = 0,
                            Text = "How would you rate the professionalism of our staff?"
                        },
                        new
                        {
                            Id = 12,
                            QuestionType = 2,
                            Rating = 0,
                            Text = "How satisfied were you with the co-ordination between different departments?"
                        },
                        new
                        {
                            Id = 13,
                            QuestionType = 2,
                            Rating = 0,
                            Text = "Do you feel that our work hours are well suited to treat you?"
                        },
                        new
                        {
                            Id = 14,
                            QuestionType = 2,
                            Rating = 0,
                            Text = "How likely are you to recommend our hospital to a friend or family member?"
                        });
                });

            modelBuilder.Entity("Hospital.MedicalRecords.Model.UserFeedback", b =>
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
                            TimeWritten = new DateTime(2021, 12, 19, 14, 9, 14, 853, DateTimeKind.Local).AddTicks(9154),
                            canPublish = false
                        },
                        new
                        {
                            Id = 2,
                            Content = "I didn't like it.",
                            Name = "Anonymus",
                            TimeWritten = new DateTime(2021, 12, 19, 14, 9, 14, 861, DateTimeKind.Local).AddTicks(6766),
                            canPublish = false
                        },
                        new
                        {
                            Id = 3,
                            Content = "Super service!",
                            Name = "Sara Saric",
                            TimeWritten = new DateTime(2021, 12, 19, 14, 9, 14, 861, DateTimeKind.Local).AddTicks(7210),
                            canPublish = false
                        });
                });

            modelBuilder.Entity("Hospital.Medicines.Model.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Manufacturer")
                        .HasColumnType("text");

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

                    b.Property<int>("Supply")
                        .HasColumnType("integer");

                    b.Property<string>("Usage")
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Medicines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Manufacturer = "Pfizer",
                            MedicineImage = "",
                            Name = "Brufen",
                            Precautions = "Mozes sve lagano",
                            Price = 200.0,
                            Reactions = "Pa umres",
                            SideEffects = "Umres",
                            Supply = 100,
                            Usage = "Kad god hoces",
                            Weight = 100.0
                        });
                });

            modelBuilder.Entity("Hospital.Schedule.Model.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApointmentDescription")
                        .HasColumnType("text");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("DurationInMunutes")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SurveyId")
                        .HasColumnType("integer");

                    b.Property<bool>("canCancel")
                        .HasColumnType("boolean");

                    b.Property<bool>("isCancelled")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApointmentDescription = "All good",
                            DoctorId = 1,
                            DurationInMunutes = 30,
                            IsDeleted = false,
                            PatientId = 1,
                            StartTime = new DateTime(2021, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            SurveyId = 0,
                            canCancel = true,
                            isCancelled = false
                        },
                        new
                        {
                            Id = 2,
                            ApointmentDescription = "",
                            DoctorId = 1,
                            DurationInMunutes = 30,
                            IsDeleted = false,
                            PatientId = 2,
                            StartTime = new DateTime(2022, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified),
                            SurveyId = 0,
                            canCancel = true,
                            isCancelled = false
                        },
                        new
                        {
                            Id = 3,
                            ApointmentDescription = "All good",
                            DoctorId = 1,
                            DurationInMunutes = 30,
                            IsDeleted = false,
                            PatientId = 2,
                            StartTime = new DateTime(2021, 12, 7, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            SurveyId = 0,
                            canCancel = true,
                            isCancelled = false
                        },
                        new
                        {
                            Id = 4,
                            ApointmentDescription = "All good",
                            DoctorId = 1,
                            DurationInMunutes = 30,
                            IsDeleted = false,
                            PatientId = 2,
                            StartTime = new DateTime(2021, 11, 15, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            SurveyId = 0,
                            canCancel = true,
                            isCancelled = true
                        });
                });

            modelBuilder.Entity("Hospital.Schedule.Model.VacationDays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("VacationDays");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Hospital.Schedule.Model.WorkingHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BeginningDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Shift")
                        .HasColumnType("integer");

                    b.HasKey("Id");

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

            modelBuilder.Entity("Hospital.SharedModel.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("text");

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

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Bulevar Oslobodjenja 4",
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
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Ravanicka 8",
                            DateOfBirth = new DateTime(1987, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "milica@gmail.com",
                            Jmbg = "3052123545852",
                            Name = "Milica",
                            NumberOfPatients = 0,
                            Password = "mica1234",
                            PhoneNumber = "0691457608",
                            SalaryInRsd = 250000,
                            Sex = 1,
                            SpecialityId = 2,
                            Surname = "Milic",
                            Type = 2,
                            Username = "mica56"
                        });
                });

            modelBuilder.Entity("Hospital.SharedModel.Speciality", b =>
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
                        },
                        new
                        {
                            Id = 2,
                            Name = "cardiology"
                        });
                });

            modelBuilder.Entity("Hospital.MedicalRecords.Model.Allergen", b =>
                {
                    b.HasOne("Hospital.MedicalRecords.Model.Patient", null)
                        .WithMany("Allergen")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hospital.MedicalRecords.Model.Patient", b =>
                {
                    b.Navigation("Allergen");
                });
#pragma warning restore 612, 618
        }
    }
}
