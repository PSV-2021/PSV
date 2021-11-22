using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class datatbaseTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugstores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DrugstoreFeedbacks",
                columns: new[] { "Id", "Content", "DrugstoreId", "RecievedTime", "Response", "SentTime" },
                values: new object[,]
                {
                    { "aaa", "Nije mi se svidela usluga", 1, new DateTime(2021, 11, 22, 17, 27, 48, 37, DateTimeKind.Local).AddTicks(9840), "Nemoj da lazes!", new DateTime(2021, 11, 22, 17, 27, 48, 56, DateTimeKind.Local).AddTicks(6498) },
                    { "bbb", "Svidjela usluga", 2, new DateTime(2021, 11, 22, 17, 27, 48, 56, DateTimeKind.Local).AddTicks(7898), "Nemoj da lazes!", new DateTime(2021, 11, 22, 17, 27, 48, 56, DateTimeKind.Local).AddTicks(7952) },
                    { "ccc", "Nije mi se svidela usluga", 3, new DateTime(2021, 11, 22, 17, 27, 48, 56, DateTimeKind.Local).AddTicks(7976), "Nemoj da lazes!", new DateTime(2021, 11, 22, 17, 27, 48, 56, DateTimeKind.Local).AddTicks(7982) }
                });

            migrationBuilder.InsertData(
                table: "DrugstoreOffers",
                columns: new[] { "Id", "Content", "DrugstoreName", "EndDate", "IsPublished", "StartDate", "Title" },
                values: new object[] { "1", "Content", "Apotekica", new DateTime(2021, 11, 22, 17, 27, 48, 56, DateTimeKind.Local).AddTicks(9276), false, new DateTime(2021, 11, 22, 17, 27, 48, 56, DateTimeKind.Local).AddTicks(9256), "title" });

            migrationBuilder.InsertData(
                table: "Drugstores",
                columns: new[] { "Id", "Address", "ApiKey", "City", "Email", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Tolstojeva 3", "DrugStoreSecretKey", "Novi Sad", "apoteka1@gmail.com", "Apoteka prva", "http://localhost:5001" },
                    { 2, "Balzakova 3", "wnjgjowenfweo", "Novi Sad", "apoteka2@gmail.com", "Apoteka druga", "http://localhost:5002" },
                    { 3, "Puskinova 3", "wuhguiwoehfuhw", "Beograd", "apoteka3@gmail.com", "Apoteka treca", "http://localhost:5003" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugstoreFeedbacks");

            migrationBuilder.DropTable(
                name: "DrugstoreOffers");

            migrationBuilder.DropTable(
                name: "Drugstores");
        }
    }
}
