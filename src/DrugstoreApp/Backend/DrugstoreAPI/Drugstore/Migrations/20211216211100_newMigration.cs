﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Drugstore.Migrations
{
    public partial class idegas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugSpecifications",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugSpecifications", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "DrugstoreOffers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DrugstoreName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugstoreOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HospitalName = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Response = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    ApiKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
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
                    MedicineImage = table.Column<string>(type: "text", nullable: true),
                    Substances = table.Column<string>(type: "text", nullable: true),
                    MedicineId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Customer_Name = table.Column<string>(type: "text", nullable: true),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "DrugSpecifications",
                columns: new[] { "Name", "Text" },
                values: new object[,]
                {
                    { "Brufen", "Ovde ide tekst specifikacije za Brufen" },
                    { "Paracetamol", "Ovde ide tekst specifikacije za Paracetamol" },
                    { "Palitreks", "Ovde ide tekst specifikacije za Palitreks" }
                });

            migrationBuilder.InsertData(
                table: "DrugstoreOffers",
                columns: new[] { "Id", "Content", "DrugstoreName", "EndDate", "StartDate", "Title" },
<<<<<<< HEAD:src/DrugstoreApp/Backend/DrugstoreAPI/Drugstore/Migrations/20211216211100_newMigration.cs
                values: new object[] { "1", "Content", "Apotekica", new DateTime(2021, 12, 16, 22, 10, 59, 863, DateTimeKind.Local).AddTicks(6251), new DateTime(2021, 12, 16, 22, 10, 59, 861, DateTimeKind.Local).AddTicks(4581), "title" });
=======
                values: new object[] { "1", "Content", "Apotekica", new DateTime(2021, 12, 21, 21, 2, 22, 867, DateTimeKind.Local).AddTicks(5716), new DateTime(2021, 12, 21, 21, 2, 22, 865, DateTimeKind.Local).AddTicks(4584), "title" });
>>>>>>> development:src/DrugstoreApp/Backend/DrugstoreAPI/Drugstore/Migrations/20211221200223_idegas.cs

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "HospitalName", "Response" },
                values: new object[,]
                {
                    { "aaa", "Lenka vrati zeton", "Health", "" },
                    { "bbb", "normalno", "Ime bolnice 223", "" },
                    { "ccc", "bla bla", "Ime bolnice 224", "" }
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "ApiKey", "Name", "Url" },
                values: new object[] { 1, "DrugStoreSecretKey", "Health", "http://localhost:5000" });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Manufacturer", "MedicineId", "MedicineImage", "Name", "Precautions", "Price", "Reactions", "SideEffects", "Substances", "Supply", "Usage", "Weight" },
                values: new object[,]
                {
                    { 1, "bla", null, null, "Brufen", "bla", 150.0, "bla", "bla", "bla", 150, "bla", 100.0 },
                    { 2, "bla", null, null, "Paracetamol", "bla", 150.0, "bla", "bla", "bla", 10, "bla", 100.0 },
                    { 3, "bla", null, null, "Palitreks", "bla", 150.0, "bla", "bla", "bla", 30, "bla", 100.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Adress", "Discriminator", "Customer_Name", "Password", "Role", "Username" },
                values: new object[] { 5, "Adresa kupca 123", "Customer", "Kupac", "kupac", "Customer", "kupac" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Name", "Password", "Role", "Username" },
                values: new object[] { 1, "Pharmacist", "Farmaceut", "farmaceut", "Pharmacist", "farmaceut" });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineId",
                table: "Medicines",
                column: "MedicineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugSpecifications");

            migrationBuilder.DropTable(
                name: "DrugstoreOffers");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
