using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class UpdateIntegration : Migration
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
                    ApiKey = table.Column<string>(type: "text", nullable: true)
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
                    { "aaa", "Nije mi se svidela usluga", 1, new DateTime(2021, 11, 5, 21, 26, 28, 229, DateTimeKind.Local).AddTicks(5685), "Nemoj da lazes!", new DateTime(2021, 11, 5, 21, 26, 28, 232, DateTimeKind.Local).AddTicks(6668) },
                    { "bbb", "Svidjela usluga", 2, new DateTime(2021, 11, 5, 21, 26, 28, 232, DateTimeKind.Local).AddTicks(7004), "Nemoj da lazes!", new DateTime(2021, 11, 5, 21, 26, 28, 232, DateTimeKind.Local).AddTicks(7031) },
                    { "ccc", "Nije mi se svidela usluga", 3, new DateTime(2021, 11, 5, 21, 26, 28, 232, DateTimeKind.Local).AddTicks(7049), "Nemoj da lazes!", new DateTime(2021, 11, 5, 21, 26, 28, 232, DateTimeKind.Local).AddTicks(7052) }
                });

            migrationBuilder.InsertData(
                table: "Drugstores",
                columns: new[] { "Id", "ApiKey", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "aaabbbccc", "Apoteka prva", "www.apoteka.rs" },
                    { 2, "111222333", "Apoteka druga", "www.apotekica.rs" },
                    { 3, "555333", "Apoteka treca", "www.apotekcina.rs" }
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
