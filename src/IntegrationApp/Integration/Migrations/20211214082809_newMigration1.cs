using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class newMigration1 : Migration
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
                    Email = table.Column<string>(type: "text", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Supply = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DrugsConsumed",
                columns: new[] { "Id", "Amount", "DateConsumed", "Name" },
                values: new object[,]
                {
                    { 27, 64, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 25, 54, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 26, 77, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 28, 38, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 29, 78, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 30, 66, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 31, 87, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 32, 56, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 33, 45, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 34, 56, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 35, 76, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 24, 42, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 36, 93, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 38, 49, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 39, 46, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 40, 72, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 41, 60, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 42, 34, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 43, 97, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 44, 62, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 45, 39, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 46, 46, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 47, 77, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 37, 62, new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 48, 60, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 23, 66, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 21, 39, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 1, 98, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 2, 65, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 3, 45, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amoksicilin" },
                    { 4, 43, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 5, 67, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andol" },
                    { 6, 65, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panadol" },
                    { 7, 36, new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" },
                    { 8, 76, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
                    { 9, 56, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palitrex" },
                    { 22, 105, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brufen" },
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
                    { 11, 34, new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinacilin" },
                    { 49, 38, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panklav" }
                });

            migrationBuilder.InsertData(
                table: "DrugstoreFeedbacks",
                columns: new[] { "Id", "Content", "DrugstoreId", "RecievedTime", "Response", "SentTime" },
                values: new object[,]
                {
                    { "ccc", "Nije mi se svidela usluga", 3, new DateTime(2021, 12, 14, 9, 28, 8, 901, DateTimeKind.Local).AddTicks(5569), "Nemoj da lazes!", new DateTime(2021, 12, 14, 9, 28, 8, 901, DateTimeKind.Local).AddTicks(5573) },
                    { "aaa", "Nije mi se svidela usluga", 1, new DateTime(2021, 12, 14, 9, 28, 8, 898, DateTimeKind.Local).AddTicks(3425), "Nemoj da lazes!", new DateTime(2021, 12, 14, 9, 28, 8, 901, DateTimeKind.Local).AddTicks(5118) },
                    { "bbb", "Svidjela usluga", 2, new DateTime(2021, 12, 14, 9, 28, 8, 901, DateTimeKind.Local).AddTicks(5517), "Nemoj da lazes!", new DateTime(2021, 12, 14, 9, 28, 8, 901, DateTimeKind.Local).AddTicks(5546) }
                });

            migrationBuilder.InsertData(
                table: "DrugstoreOffers",
                columns: new[] { "Id", "Content", "DrugstoreName", "EndDate", "IsPublished", "StartDate", "Title" },
                values: new object[] { "1", "Content", "Apotekica", new DateTime(2021, 12, 14, 9, 28, 8, 901, DateTimeKind.Local).AddTicks(6075), false, new DateTime(2021, 12, 14, 9, 28, 8, 901, DateTimeKind.Local).AddTicks(6069), "title" });

            migrationBuilder.InsertData(
                table: "Drugstores",
                columns: new[] { "Id", "Address", "ApiKey", "Base64Image", "City", "Comment", "Email", "Name", "Url", "gRPC" },
                values: new object[,]
                {
                    { 2, "Balzakova 3", "wnjgjowenfweo", null, "Novi Sad", null, "apoteka2@gmail.com", "Apoteka druga", "http://localhost:5002", false },
                    { 3, "Puskinova 3", "wuhguiwoehfuhw", null, "Beograd", null, "apoteka3@gmail.com", "Apoteka treca", "http://localhost:5003", false },
                    { 1, "Tolstojeva 3", "DrugStoreSecretKey", null, "Novi Sad", null, "apoteka1@gmail.com", "Apoteka prva", "http://localhost:5001", true }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Name", "Supply" },
                values: new object[,]
                {
                    { 3, "Palitreks", 0 },
                    { 2, "Paracetamol", 0 },
                    { 1, "Brufen", 0 }
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
                name: "Medicines");
        }
    }
}
