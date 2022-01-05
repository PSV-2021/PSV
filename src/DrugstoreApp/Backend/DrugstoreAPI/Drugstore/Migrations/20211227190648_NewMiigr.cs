using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Drugstore.Migrations
{
    public partial class NewMiigr : Migration
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

            migrationBuilder.CreateTable(
                name: "TenderOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenderOfferInfo = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    TenderId = table.Column<int>(type: "integer", nullable: false),
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
                    { 1, new DateTime(2021, 12, 20, 20, 6, 47, 970, DateTimeKind.Local).AddTicks(402), "Brufen - 150, Palitreks - 100, Andol - 40", true },
                    { 2, new DateTime(2022, 1, 17, 20, 6, 47, 970, DateTimeKind.Local).AddTicks(1673), "Brufen - 120, Palitreks - 90, Andol - 50", false }
                });

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 27, 20, 6, 47, 969, DateTimeKind.Local).AddTicks(7135), new DateTime(2021, 12, 27, 20, 6, 47, 967, DateTimeKind.Local).AddTicks(8935) });

            migrationBuilder.InsertData(
                table: "TenderOffers",
                columns: new[] { "Id", "DrugstoreId", "IsAccepted", "IsActive", "Price", "TenderId", "TenderOfferInfo" },
                values: new object[,]
                {
                    { 1, 1, false, true, 5000, 2, "Brufen - 100, Palitreks - 80, Andol - 40" },
                    { 2, 2, false, true, 5900, 2, "Brufen - 120, Palitreks - 50, Andol - 35" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugTenders");

            migrationBuilder.DropTable(
                name: "TenderOffers");

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 23, 3, 44, 0, 183, DateTimeKind.Local).AddTicks(9798), new DateTime(2021, 12, 23, 3, 44, 0, 174, DateTimeKind.Local).AddTicks(1759) });
        }
    }
}
