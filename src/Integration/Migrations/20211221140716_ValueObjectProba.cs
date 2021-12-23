using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
<<<<<<< HEAD:src/IntegrationApp/Integration/Migrations/20211219201237_newMigration.cs
    public partial class newMigration : Migration
=======
    public partial class ValueObjectProba : Migration
>>>>>>> development:src/Integration/Migrations/20211221140716_ValueObjectProba.cs
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
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                    City = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Base64Image = table.Column<string>(type: "text", nullable: true),
                    gRPC = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugstores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DrugsConsumed",
                columns: new[] { "Id", "Amount", "DateConsumed", "Name" },
                values: new object[,]
                {
<<<<<<< HEAD:src/IntegrationApp/Integration/Migrations/20211219201237_newMigration.cs
                    { 1, 98, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
=======
                    { 23, 66, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 49, 38, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 24, 42, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 25, 54, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 26, 77, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 27, 64, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 28, 38, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
>>>>>>> development:src/Integration/Migrations/20211221140716_ValueObjectProba.cs
                    { 29, 78, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 30, 66, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 31, 87, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 32, 56, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 33, 45, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 34, 56, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 35, 76, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 36, 93, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 37, 62, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 38, 49, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 39, 46, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 40, 72, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 41, 60, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 42, 34, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 43, 97, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 22, 105, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 44, 62, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
<<<<<<< HEAD:src/IntegrationApp/Integration/Migrations/20211219201237_newMigration.cs
                    { 45, 39, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 46, 46, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 47, 77, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 48, 60, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 49, 38, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 27, 64, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 26, 77, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 28, 38, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 24, 42, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
=======
                    { 21, 39, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 19, 56, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 48, 60, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 47, 77, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 46, 46, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 1, 98, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
>>>>>>> development:src/Integration/Migrations/20211221140716_ValueObjectProba.cs
                    { 2, 65, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 3, 45, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 4, 43, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 5, 67, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 6, 65, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 7, 36, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 8, 76, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 9, 56, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
<<<<<<< HEAD:src/IntegrationApp/Integration/Migrations/20211219201237_newMigration.cs
                    { 25, 54, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
=======
                    { 10, 54, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
>>>>>>> development:src/Integration/Migrations/20211221140716_ValueObjectProba.cs
                    { 11, 34, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 12, 87, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 10, 54, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 14, 33, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
<<<<<<< HEAD:src/IntegrationApp/Integration/Migrations/20211219201237_newMigration.cs
                    { 23, 66, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 13, 67, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 21, 39, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 20, 75, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 22, 105, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 18, 44, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 17, 48, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 16, 66, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 15, 78, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 19, 56, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" }
                });

            migrationBuilder.InsertData(
                table: "DrugstoreFeedbacks",
                columns: new[] { "Id", "Content", "DrugstoreId", "RecievedTime", "Response", "SentTime" },
                values: new object[,]
                {
                    { "ccc", "Nije mi se svidela usluga", 3, new DateTime(2021, 12, 19, 21, 12, 36, 832, DateTimeKind.Local).AddTicks(1242), "Nemoj da lazes!", new DateTime(2021, 12, 19, 21, 12, 36, 832, DateTimeKind.Local).AddTicks(1247) },
                    { "aaa", "Nije mi se svidela usluga", 1, new DateTime(2021, 12, 19, 21, 12, 36, 826, DateTimeKind.Local).AddTicks(987), "Nemoj da lazes!", new DateTime(2021, 12, 19, 21, 12, 36, 832, DateTimeKind.Local).AddTicks(489) },
                    { "bbb", "Svidjela usluga", 2, new DateTime(2021, 12, 19, 21, 12, 36, 832, DateTimeKind.Local).AddTicks(1172), "Nemoj da lazes!", new DateTime(2021, 12, 19, 21, 12, 36, 832, DateTimeKind.Local).AddTicks(1223) }
=======
                    { 15, 78, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 16, 66, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 17, 48, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 18, 44, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 20, 75, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 45, 39, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" }
>>>>>>> development:src/Integration/Migrations/20211221140716_ValueObjectProba.cs
                });

            migrationBuilder.InsertData(
                table: "DrugstoreOffers",
                columns: new[] { "Id", "Content", "DrugstoreName", "EndDate", "IsPublished", "StartDate", "Title" },
<<<<<<< HEAD:src/IntegrationApp/Integration/Migrations/20211219201237_newMigration.cs
                values: new object[] { "1", "Content", "Apotekica", new DateTime(2021, 12, 19, 21, 12, 36, 832, DateTimeKind.Local).AddTicks(1982), false, new DateTime(2021, 12, 19, 21, 12, 36, 832, DateTimeKind.Local).AddTicks(1973), "title" });

            migrationBuilder.InsertData(
                table: "Drugstores",
                columns: new[] { "Id", "Address", "ApiKey", "Base64Image", "City", "Comment", "Email", "Name", "Url", "gRPC" },
                values: new object[,]
                {
                    { 1, "Tolstojeva 3", "DrugStoreSecretKey", null, "Novi Sad", null, "apoteka1@gmail.com", "Apoteka prva", "http://localhost:5001", true },
                    { 2, "Balzakova 3", "wnjgjowenfweo", null, "Novi Sad", null, "apoteka2@gmail.com", "Apoteka druga", "http://localhost:5002", false },
                    { 3, "Puskinova 3", "wuhguiwoehfuhw", null, "Beograd", null, "apoteka3@gmail.com", "Apoteka treca", "http://localhost:5003", false }
=======
                values: new object[] { "1", "Content", "Apotekica", new DateTime(2021, 12, 21, 15, 7, 16, 306, DateTimeKind.Local).AddTicks(9348), false, new DateTime(2021, 12, 21, 15, 7, 16, 304, DateTimeKind.Local).AddTicks(8690), "title" });

            migrationBuilder.InsertData(
                table: "Drugstores",
                columns: new[] { "Id", "Address", "ApiKey", "Base64Image", "City", "Comment", "Name", "Url", "gRPC", "Email_EmailValue" },
                values: new object[] { 1, "Tolstojeva 3", "DrugStoreSecretKey", null, "Novi Sad", null, "Apoteka prva", "http://localhost:5001", true, "apotekaprva@gmail.com" });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Name", "Supply" },
                values: new object[,]
                {
                    { 2, "Paracetamol", 0 },
                    { 1, "Brufen", 0 },
                    { 3, "Palitreks", 0 }
>>>>>>> development:src/Integration/Migrations/20211221140716_ValueObjectProba.cs
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
        }
    }
}
