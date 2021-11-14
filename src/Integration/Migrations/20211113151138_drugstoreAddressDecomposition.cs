using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class drugstoreAddressDecomposition : Migration
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
                    { "aaa", "Nije mi se svidela usluga", 1, new DateTime(2021, 11, 13, 16, 11, 37, 551, DateTimeKind.Local).AddTicks(5694), "Nemoj da lazes!", new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(1709) },
                    { "bbb", "Svidjela usluga", 2, new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(2037), "Nemoj da lazes!", new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(2062) },
                    { "ccc", "Nije mi se svidela usluga", 3, new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(2074), "Nemoj da lazes!", new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(2077) }
                });

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
                name: "Drugstores");
        }
    }
}
