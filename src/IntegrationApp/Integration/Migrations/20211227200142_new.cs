using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderEnd",
                value: new DateTime(2021, 12, 20, 21, 1, 40, 816, DateTimeKind.Local).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TenderEnd",
                value: new DateTime(2022, 1, 17, 21, 1, 40, 822, DateTimeKind.Local).AddTicks(672));

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
                columns: new[] { "IsAccepted", "TenderId" },
                values: new object[] { true, 1 });

            migrationBuilder.InsertData(
                table: "TenderOffers",
                columns: new[] { "Id", "DrugstoreId", "IsAccepted", "IsActive", "Price", "TenderId", "TenderOfferInfo" },
                values: new object[,]
                {
                    { 3, 1, true, true, 4000, 2, "Brufen - 100, Palitreks - 80, Andol - 40" },
                    { 4, 2, false, true, 5900, 2, "Brufen - 120, Palitreks - 50, Andol - 35" },
                    { 5, 3, false, true, 6000, 2, "Brufen - 100, Palitreks - 80, Andol - 40" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TenderOffers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TenderOffers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TenderOffers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "TenderEnd",
                value: new DateTime(2021, 12, 20, 15, 33, 36, 534, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TenderEnd",
                value: new DateTime(2022, 1, 17, 15, 33, 36, 538, DateTimeKind.Local).AddTicks(5467));

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
                columns: new[] { "IsAccepted", "TenderId" },
                values: new object[] { false, 2 });
        }
    }
}
