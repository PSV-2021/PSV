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
    [Migration("20211116180422_fifthMigration")]
    partial class fifthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Hospital.Model.Survey", b =>
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            Date = new DateTime(2021, 11, 16, 19, 4, 21, 227, DateTimeKind.Local).AddTicks(8175),
                            PatientId = 1
                        });
                });

            modelBuilder.Entity("Hospital.Model.SurveyQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("QuestionType")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

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
                            TimeWritten = new DateTime(2021, 11, 16, 19, 4, 21, 216, DateTimeKind.Local).AddTicks(6879),
                            canPublish = false
                        },
                        new
                        {
                            Id = 2,
                            Content = "I didn't like it.",
                            Name = "Anonymus",
                            TimeWritten = new DateTime(2021, 11, 16, 19, 4, 21, 225, DateTimeKind.Local).AddTicks(5223),
                            canPublish = true
                        },
                        new
                        {
                            Id = 3,
                            Content = "Super service!",
                            Name = "Sara Saric",
                            TimeWritten = new DateTime(2021, 11, 16, 19, 4, 21, 225, DateTimeKind.Local).AddTicks(5407),
                            canPublish = true
                        });
                });

            modelBuilder.Entity("Hospital.Model.SurveyQuestion", b =>
                {
                    b.HasOne("Hospital.Model.Survey", null)
                        .WithMany("SurveyQuestions")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("Hospital.Model.Survey", b =>
                {
                    b.Navigation("SurveyQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
