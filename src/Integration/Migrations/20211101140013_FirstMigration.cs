using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration_API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugstoreFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrugstoreToken = table.Column<string>(type: "text", nullable: true),
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
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugstores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DrugstoreFeedbacks",
                columns: new[] { "Id", "Content", "DrugstoreToken", "RecievedTime", "Response", "SentTime" },
                values: new object[,]
                {
                    { 1, "Nije mi se svidela usluga", "tokentokentoken123", new DateTime(2021, 11, 1, 15, 0, 12, 762, DateTimeKind.Local).AddTicks(5846), "Nemoj da lazes!", new DateTime(2021, 11, 1, 15, 0, 12, 768, DateTimeKind.Local).AddTicks(7287) },
                    { 2, "Svidjela usluga", "tokentokentoken456", new DateTime(2021, 11, 1, 15, 0, 12, 768, DateTimeKind.Local).AddTicks(8195), "Nemoj da lazes!", new DateTime(2021, 11, 1, 15, 0, 12, 768, DateTimeKind.Local).AddTicks(8249) },
                    { 3, "Nije mi se svidela usluga", "tokentokentoken789", new DateTime(2021, 11, 1, 15, 0, 12, 768, DateTimeKind.Local).AddTicks(8274), "Nemoj da lazes!", new DateTime(2021, 11, 1, 15, 0, 12, 768, DateTimeKind.Local).AddTicks(8281) }
                });

            migrationBuilder.InsertData(
                table: "Drugstores",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { "aaa", "Apoteka 1", "http://apoteka1.rs" },
                    { "bbb", "Apoteka 2", "http://apoteka2.rs" },
                    { "ccc", "Apoteka 3", "http://apoteka3.rs" }
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
