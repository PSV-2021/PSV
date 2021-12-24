using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class tenderOfferTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderEnd",
                value: new DateTime(2021, 12, 18, 0, 11, 31, 414, DateTimeKind.Local).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "TenderOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TenderOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "TenderId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderEnd",
                value: new DateTime(2021, 12, 17, 23, 36, 28, 937, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "TenderOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TenderOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "TenderId",
                value: 1);
        }
    }
}
