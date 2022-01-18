using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Drugstore.Migrations
{
    public partial class novaSaEventovima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DrugstoreEvents");

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
                name: "DrugstoreEvents",
                schema: "DrugstoreEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    EventTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugstoreEvents", x => x.Id);
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
                name: "DrugTenders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TenderEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TenderInfo = table.Column<string>(type: "text", nullable: true),
                    isFinished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugTenders", x => x.Id);
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
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Posted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Recipients = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    OrderType = table.Column<int>(type: "integer", nullable: false),
                    Delivered = table.Column<bool>(type: "boolean", nullable: false),
                    PickedUp = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenderOffers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TenderOfferInfo = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    TenderId = table.Column<string>(type: "text", nullable: true),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false),
                    DrugstoreId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOffers", x => x.Id);
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
                table: "DrugTenders",
                columns: new[] { "Id", "TenderEnd", "TenderInfo", "isFinished" },
                values: new object[,]
                {
                    { "as", new DateTime(2022, 1, 8, 16, 5, 53, 841, DateTimeKind.Local).AddTicks(3832), "Brufen - 150, Palitreks - 100, Andol - 40", true },
                    { "2", new DateTime(2022, 2, 5, 16, 5, 53, 841, DateTimeKind.Local).AddTicks(6444), "Brufen - 120, Palitreks - 90, Andol - 50", false }
                });

            migrationBuilder.InsertData(
                table: "DrugstoreOffers",
                columns: new[] { "Id", "Content", "DrugstoreName", "EndDate", "StartDate", "Title" },
                values: new object[] { "1", "Content", "Apotekica", new DateTime(2022, 1, 15, 16, 5, 53, 840, DateTimeKind.Local).AddTicks(2372), new DateTime(2022, 1, 15, 16, 5, 53, 834, DateTimeKind.Local).AddTicks(8073), "title" });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "HospitalName", "Response" },
                values: new object[,]
                {
                    { "ccc", "bla bla", "Ime bolnice 224", "" },
                    { "aaa", "Lenka vrati zeton", "Health", "" },
                    { "bbb", "normalno", "Ime bolnice 223", "" }
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
                table: "Notifications",
                columns: new[] { "Id", "Content", "Posted", "Recipients", "Title" },
                values: new object[,]
                {
                    { 3, "Obavestenje o promeni cena", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vazno obavestenje" },
                    { 1, "Aloaloalo", new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uzbuna" },
                    { 2, "Stigli su novi lekovi", new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Novi lekovi" }
                });

            migrationBuilder.InsertData(
                table: "TenderOffers",
                columns: new[] { "Id", "DrugstoreId", "IsAccepted", "IsActive", "Price", "TenderId", "TenderOfferInfo" },
                values: new object[,]
                {
                    { "2", 2, false, true, 5900, "2", "Brufen - 120, Palitreks - 50, Andol - 35" },
                    { "1", 1, false, true, 5000, "as", "Brufen - 100, Palitreks - 80, Andol - 40" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Name", "Password", "Role", "Username" },
                values: new object[] { 1, "Pharmacist", "Farmaceut", "farmaceut", "Pharmacist", "farmaceut" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Adress", "Discriminator", "Customer_Name", "Password", "Role", "Username" },
                values: new object[] { 5, "Adresa kupca 123", "Customer", "Kupac", "kupac", "Customer", "kupac" });

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
                name: "DrugstoreEvents",
                schema: "DrugstoreEvents");

            migrationBuilder.DropTable(
                name: "DrugstoreOffers");

            migrationBuilder.DropTable(
                name: "DrugTenders");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "TenderOffers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
