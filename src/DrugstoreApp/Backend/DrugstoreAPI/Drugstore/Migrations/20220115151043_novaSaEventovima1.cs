using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Drugstore.Migrations
{
    public partial class novaSaEventovima1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "2",
                column: "TenderEnd",
                value: new DateTime(2022, 2, 5, 16, 10, 42, 20, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "as",
                column: "TenderEnd",
                value: new DateTime(2022, 1, 8, 16, 10, 42, 19, DateTimeKind.Local).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 15, 16, 10, 42, 18, DateTimeKind.Local).AddTicks(6949), new DateTime(2022, 1, 15, 16, 10, 42, 14, DateTimeKind.Local).AddTicks(998) });

            migrationBuilder.InsertData(
                schema: "DrugstoreEvents",
                table: "DrugstoreEvents",
                columns: new[] { "Id", "EventName", "EventTime" },
                values: new object[] { 1, "Klik", new DateTime(2022, 1, 15, 16, 10, 42, 20, DateTimeKind.Local).AddTicks(7795) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "DrugstoreEvents",
                table: "DrugstoreEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "2",
                column: "TenderEnd",
                value: new DateTime(2022, 2, 5, 16, 5, 53, 841, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "as",
                column: "TenderEnd",
                value: new DateTime(2022, 1, 8, 16, 5, 53, 841, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 15, 16, 5, 53, 840, DateTimeKind.Local).AddTicks(2372), new DateTime(2022, 1, 15, 16, 5, 53, 834, DateTimeKind.Local).AddTicks(8073) });
        }
    }
}
