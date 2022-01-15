﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class novaSaEventovima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PatientEvent");

            migrationBuilder.CreateTable(
                name: "AnsweredQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    QuestionType = table.Column<int>(type: "integer", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnsweredQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DurationInMunutes = table.Column<int>(type: "integer", nullable: false),
                    ApointmentDescription = table.Column<string>(type: "text", nullable: true),
                    isCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    canCancel = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SpecialityId = table.Column<int>(type: "integer", nullable: false),
                    NumberOfPatients = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Jmbg = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    SalaryInRsd = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingridients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingridients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Supply = table.Column<int>(type: "integer", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    SideEffects = table.Column<string>(type: "text", nullable: true),
                    Reactions = table.Column<string>(type: "text", nullable: true),
                    Usage = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Precautions = table.Column<string>(type: "text", nullable: true),
                    MedicineImage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientEvents",
                schema: "PatientEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    EventTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    FathersName = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    MedicalRecord_HealthInsuranceNumber = table.Column<string>(type: "text", nullable: true),
                    MedicalRecord_CompanyName = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Jmbg = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DrugName = table.Column<string>(type: "text", nullable: true),
                    IssuedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    QuestionType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeWritten = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    canPublish = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeginningDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Shift = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergens_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "ApointmentDescription", "DoctorId", "DurationInMunutes", "IsDeleted", "PatientId", "StartTime", "SurveyId", "canCancel", "isCancelled" },
                values: new object[,]
                {
                    { 4, "All good", 1, 30, false, 2, new DateTime(2021, 11, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, true, true },
                    { 3, "All good", 1, 30, false, 2, new DateTime(2021, 12, 7, 14, 30, 0, 0, DateTimeKind.Unspecified), 0, true, false },
                    { 2, "", 1, 30, false, 2, new DateTime(2021, 12, 31, 16, 30, 0, 0, DateTimeKind.Unspecified), 0, true, false },
                    { 1, "All good", 1, 30, false, 1, new DateTime(2021, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), 0, true, false }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Adress", "DateOfBirth", "Email", "Jmbg", "Name", "NumberOfPatients", "Password", "PhoneNumber", "SalaryInRsd", "Sex", "SpecialityId", "Surname", "Type", "Username" },
                values: new object[,]
                {
                    { 2, "Ravanicka 8", new DateTime(1987, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "milica@gmail.com", "3052123545852", "Milica", 0, "mica1234", "0691457608", 250000, 1, 2, "Milic", 2, "mica56" },
                    { 1, "Bulevar Oslobodjenja 4", new DateTime(1998, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "milan@gmail.com", "3009998805137", "Milan", 0, "02145", "0641664608", 200000, 0, 1, "Popovic", 2, "miki56" }
                });

            migrationBuilder.InsertData(
                table: "Ingridients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Panclav" },
                    { 2, "Penicilin" },
                    { 3, "Panadol" }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Manufacturer", "MedicineImage", "Name", "Precautions", "Price", "Reactions", "SideEffects", "Supply", "Usage", "Weight" },
                values: new object[] { 1, "Pfizer", "", "Brufen", "Mozes sve lagano", 200.0, "Pa umres", "Umres", 100, "Kad god hoces", 100.0 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Adress", "BloodType", "DateOfBirth", "DoctorId", "Email", "FathersName", "Image", "IsActive", "Jmbg", "Name", "Password", "PhoneNumber", "Sex", "Surname", "Token", "Type", "Username", "MedicalRecord_CompanyName", "MedicalRecord_HealthInsuranceNumber" },
                values: new object[,]
                {
                    { 1, "Bulevar Oslobodjenja 8", 1, new DateTime(1998, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "marko@gmail.com", "Petar", new byte[0], true, "3009998805138", "Marko", "miki985", "0641664608", 0, "Markovic", null, 0, "miki98", "WellCare", "1ab" },
                    { 2, "Kisacka 5", 0, new DateTime(1997, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "milica@gmail.com", "Nenad", new byte[0], true, "3009998805137", "Milica", "mici789", "065245987", 1, "Mikic", null, 0, "mici97", "WellCare", "2ab" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "Description", "DrugName", "IssuedTime", "PatientName" },
                values: new object[] { 1, "Random opis nekog leka", "Palitrex", new DateTime(2022, 1, 15, 16, 43, 17, 442, DateTimeKind.Local).AddTicks(9042), "Zoran Zoranic" });

            migrationBuilder.InsertData(
                table: "Speciality",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "general" },
                    { 2, "cardiology" }
                });

            migrationBuilder.InsertData(
                table: "SurveyQuestion",
                columns: new[] { "Id", "QuestionType", "Rating", "Text" },
                values: new object[,]
                {
                    { 10, 2, 0, "How satisfied are you with the cleanliness and appearance of our hospital?" },
                    { 1, 0, 0, "How satisfied are you with the work of your doctor?" },
                    { 2, 0, 0, "How satisfied were you with the time that your doctor spent with you?" },
                    { 3, 0, 0, "During this hospital stay, did doctor treat you with courtesy and respect?" },
                    { 4, 0, 0, "During this hospital stay, did doctor listen carefully to you?" },
                    { 5, 0, 0, "During this hospital stay, did doctor explain things in a way you could understand?" },
                    { 9, 2, 0, "How easy was it to schedule an appointment with our hospital?" },
                    { 7, 1, 0, "During this hospital stay, did nurses listen carefully to you?" },
                    { 6, 1, 0, "During this hospital stay, did nurses treat you with courtesy and respect?" },
                    { 14, 2, 0, "How likely are you to recommend our hospital to a friend or family member?" },
                    { 13, 2, 0, "Do you feel that our work hours are well suited to treat you?" },
                    { 12, 2, 0, "How satisfied were you with the co-ordination between different departments?" },
                    { 8, 1, 0, "During this hospital stay, did nurses explain things in a way you could understand?" },
                    { 11, 2, 0, "How would you rate the professionalism of our staff?" }
                });

            migrationBuilder.InsertData(
                table: "UserFeedbacks",
                columns: new[] { "Id", "Content", "Name", "TimeWritten", "canPublish" },
                values: new object[,]
                {
                    { 2, "I didn't like it.", "Anonymus", new DateTime(2022, 1, 15, 16, 43, 17, 423, DateTimeKind.Local).AddTicks(8041), true },
                    { 1, "Good!", "Mika Mikic", new DateTime(2022, 1, 15, 16, 43, 17, 418, DateTimeKind.Local).AddTicks(7186), false },
                    { 3, "Super service!", "Sara Saric", new DateTime(2022, 1, 15, 16, 43, 17, 423, DateTimeKind.Local).AddTicks(8252), true }
                });

            migrationBuilder.InsertData(
                table: "VacationDays",
                columns: new[] { "Id", "EndDate", "StartDate" },
                values: new object[] { 1, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "WorkingHours",
                columns: new[] { "Id", "BeginningDate", "EndDate", "Shift" },
                values: new object[] { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_PatientId",
                table: "Allergens",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "AnsweredQuestion");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Ingridients");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "PatientEvents",
                schema: "PatientEvent");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "SurveyQuestion");

            migrationBuilder.DropTable(
                name: "UserFeedbacks");

            migrationBuilder.DropTable(
                name: "VacationDays");

            migrationBuilder.DropTable(
                name: "WorkingHours");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
