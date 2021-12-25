using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class newTender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderEnd",
                value: new DateTime(2021, 12, 18, 20, 41, 37, 543, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.InsertData(
                table: "DrugTenders",
                columns: new[] { "Id", "TenderEnd", "TenderInfo", "isFinished" },
                values: new object[] { 2, new DateTime(2022, 1, 15, 20, 41, 37, 548, DateTimeKind.Local).AddTicks(1532), "Brufen - 120, Palitreks - 90, Andol - 50", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderEnd",
                value: new DateTime(2021, 12, 18, 0, 11, 31, 414, DateTimeKind.Local).AddTicks(1358));
        }
    }
}
