using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class tenderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugTenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenderEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TenderInfo = table.Column<string>(type: "text", nullable: true),
                    isFinished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugTenders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DrugTenders",
                columns: new[] { "Id", "TenderEnd", "TenderInfo", "isFinished" },
                values: new object[] { 1, new DateTime(2021, 12, 15, 15, 6, 8, 812, DateTimeKind.Local).AddTicks(4150), "Brufen - 150, Palitreks - 100, Andol - 40", true });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "aaa",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 12, 22, 15, 6, 8, 808, DateTimeKind.Local).AddTicks(3480), new DateTime(2021, 12, 22, 15, 6, 8, 811, DateTimeKind.Local).AddTicks(3748) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "bbb",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 12, 22, 15, 6, 8, 811, DateTimeKind.Local).AddTicks(4535), new DateTime(2021, 12, 22, 15, 6, 8, 811, DateTimeKind.Local).AddTicks(4569) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "ccc",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 12, 22, 15, 6, 8, 811, DateTimeKind.Local).AddTicks(4584), new DateTime(2021, 12, 22, 15, 6, 8, 811, DateTimeKind.Local).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 22, 15, 6, 8, 811, DateTimeKind.Local).AddTicks(5136), new DateTime(2021, 12, 22, 15, 6, 8, 811, DateTimeKind.Local).AddTicks(5128) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugTenders");

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "aaa",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 12, 12, 20, 25, 49, 142, DateTimeKind.Local).AddTicks(5313), new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(2014) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "bbb",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(3937), new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(3993) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "ccc",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(4040), new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(4047) });

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(4837), new DateTime(2021, 12, 12, 20, 25, 49, 149, DateTimeKind.Local).AddTicks(4827) });
        }
    }
}
