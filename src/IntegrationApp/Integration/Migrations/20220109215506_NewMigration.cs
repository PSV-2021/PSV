using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugsConsumed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    DateConsumed = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugsConsumed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugstoreFeedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DrugstoreId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Response = table.Column<string>(type: "text", nullable: true),
                    SentTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RecievedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugstoreFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugstoreOffers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    TimeRange_From = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TimeRange_To = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DrugstoreName = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugstoreOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugstores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    ApiKey = table.Column<string>(type: "text", nullable: true),
                    Email_EmailValue = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true),
                    Address_City = table.Column<string>(type: "text", nullable: true),
                    Address_Street = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Base64Image = table.Column<string>(type: "text", nullable: true),
                    gRPC = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugstores", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "DrugTenders",
                columns: new[] { "Id", "TenderEnd", "TenderInfo", "isFinished" },
                values: new object[,]
                {
                    { "2", new DateTime(2022, 1, 30, 22, 55, 5, 548, DateTimeKind.Local).AddTicks(2495), "Brufen - 120, Palitreks - 90, Andol - 50", false },
                    { "as", new DateTime(2022, 1, 2, 22, 55, 5, 542, DateTimeKind.Local).AddTicks(8060), "Brufen - 150, Palitreks - 100, Andol - 40", true }
                });

            migrationBuilder.InsertData(
                table: "DrugsConsumed",
                columns: new[] { "Id", "Amount", "DateConsumed", "Name" },
                values: new object[,]
                {
                    { 25, 54, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 26, 77, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 27, 64, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 28, 38, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 29, 78, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 30, 66, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 31, 87, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 32, 56, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 33, 45, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 34, 56, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 35, 76, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 37, 62, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 49, 38, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 38, 49, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 39, 46, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 40, 72, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 41, 60, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 42, 34, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 43, 97, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 44, 62, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 45, 39, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 46, 46, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 36, 93, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 24, 42, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 22, 105, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 47, 77, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 1, 98, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 2, 65, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 3, 45, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 4, 43, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 5, 67, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 6, 65, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 7, 36, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 8, 76, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 9, 56, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 23, 66, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 10, 54, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 12, 87, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 13, 67, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 14, 33, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 15, 78, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 16, 66, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 17, 48, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 18, 44, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 19, 56, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 20, 75, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 21, 39, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 11, 34, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 48, 60, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" }
                });

            migrationBuilder.InsertData(
                table: "DrugstoreOffers",
                columns: new[] { "Id", "Content", "DrugstoreName", "IsPublished", "Title", "TimeRange_From", "TimeRange_To" },
                values: new object[] { "1", "Content", "Apotekica", false, "title", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Drugstores",
                columns: new[] { "Id", "ApiKey", "Base64Image", "Comment", "Name", "Url", "gRPC", "Address_City", "Address_Country", "Address_Street", "Email_EmailValue" },
                values: new object[,]
                {
                    { 1, "DrugStoreSecretKey", null, null, "Apoteka prva", "http://localhost:5001", true, "Novi Sad", "Srbija", "Tolstojeva 5", "smrdic99@gmail.com" },
                    { 3, "gasic", null, null, "Apoteka treca", "http://localhost:7001", true, "Subotica", "Srbija", "Cara Dusana 56", "trecimejl@gmail.com" },
                    { 2, "nestorandom", null, null, "Apoteka druga", "http://localhost:6001", true, "Beograd", "Srbija", "Balzakova 31", "drugimeil@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "TenderOffers",
                columns: new[] { "Id", "DrugstoreId", "IsAccepted", "IsActive", "Price", "TenderId", "TenderOfferInfo" },
                values: new object[,]
                {
                    { "1", 1, false, true, 5000, "as", "Brufen - 100, Palitreks - 80, Andol - 40" },
                    { "2", 2, false, true, 5900, "2", "Brufen - 120, Palitreks - 50, Andol - 35" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugsConsumed");

            migrationBuilder.DropTable(
                name: "DrugstoreFeedbacks");

            migrationBuilder.DropTable(
                name: "DrugstoreOffers");

            migrationBuilder.DropTable(
                name: "Drugstores");

            migrationBuilder.DropTable(
                name: "DrugTenders");

            migrationBuilder.DropTable(
                name: "TenderOffers");
        }
    }
}
