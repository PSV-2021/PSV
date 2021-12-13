using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Drugstore.Migrations
{
    public partial class newMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugSpecifications",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugSpecifications", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "DrugSpecifications",
                columns: new[] { "Name", "Text" },
                values: new object[,]
                {
                    { "Brufen", "Ovde ide tekst specifikacije za Brufen" },
                    { "Paracetamol", "Ovde ide tekst specifikacije za Paracetamol" },
                    { "Palitreks", "Ovde ide tekst specifikacije za Palitreks" }
                });

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 12, 21, 21, 23, 573, DateTimeKind.Local).AddTicks(3007), new DateTime(2021, 12, 12, 21, 21, 23, 570, DateTimeKind.Local).AddTicks(4367) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugSpecifications");

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 11, 24, 17, 8, 27, 917, DateTimeKind.Local).AddTicks(7213), new DateTime(2021, 11, 24, 17, 8, 27, 913, DateTimeKind.Local).AddTicks(1586) });
        }
    }
}
