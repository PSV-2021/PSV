using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class ValueObjectDrugiPut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 12, 18, 870, DateTimeKind.Local).AddTicks(5104), new DateTime(2021, 12, 21, 15, 12, 18, 866, DateTimeKind.Local).AddTicks(8054) });

            migrationBuilder.InsertData(
                table: "Drugstores",
                columns: new[] { "Id", "Address", "ApiKey", "Base64Image", "City", "Comment", "Name", "Url", "gRPC", "Email_EmailValue" },
                values: new object[,]
                {
                    { 3, "Tolstojeva 3", "nestorandom", null, "Novi Sad", null, "Apoteka treca", "http://localhost:7001", true, "trecimejl@gmail.com" },
                    { 2, "Tolstojeva 3", "nestorandom", null, "Novi Sad", null, "Apoteka druga", "http://localhost:6001", true, "drugimeil@gmail.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 7, 16, 306, DateTimeKind.Local).AddTicks(9348), new DateTime(2021, 12, 21, 15, 7, 16, 304, DateTimeKind.Local).AddTicks(8690) });
        }
    }
}
