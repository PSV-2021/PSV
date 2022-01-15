using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Drugstore.Migrations
{
    public partial class dodavanjeMejla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Hospitals",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "2",
                column: "TenderEnd",
                value: new DateTime(2022, 2, 2, 23, 10, 53, 747, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "as",
                column: "TenderEnd",
                value: new DateTime(2022, 1, 5, 23, 10, 53, 747, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 12, 23, 10, 53, 746, DateTimeKind.Local).AddTicks(6457), new DateTime(2022, 1, 12, 23, 10, 53, 743, DateTimeKind.Local).AddTicks(4653) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "crnimraz99@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Hospitals");

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "2",
                column: "TenderEnd",
                value: new DateTime(2022, 1, 30, 23, 5, 3, 595, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "as",
                column: "TenderEnd",
                value: new DateTime(2022, 1, 2, 23, 5, 3, 594, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 9, 23, 5, 3, 594, DateTimeKind.Local).AddTicks(2981), new DateTime(2022, 1, 9, 23, 5, 3, 589, DateTimeKind.Local).AddTicks(4236) });
        }
    }
}
