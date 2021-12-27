using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class tenderOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderEnd",
                value: new DateTime(2021, 12, 17, 23, 36, 28, 937, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.InsertData(
                table: "TenderOffers",
                columns: new[] { "Id", "DrugstoreId", "IsAccepted", "IsActive", "Price", "TenderId", "TenderOfferInfo" },
                values: new object[,]
                {
                    { 2, 2, false, true, 5900, 1, "Brufen - 120, Palitreks - 50, Andol - 35" },
                    { 1, 1, false, true, 5000, 1, "Brufen - 100, Palitreks - 80, Andol - 40" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenderOffers");

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderEnd",
                value: new DateTime(2021, 12, 16, 22, 43, 40, 780, DateTimeKind.Local).AddTicks(7406));
        }
    }
}
