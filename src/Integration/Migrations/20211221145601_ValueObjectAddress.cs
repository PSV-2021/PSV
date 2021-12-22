using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class ValueObjectAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Drugstores",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Drugstores",
                newName: "Address_Street");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Drugstores",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 56, 0, 331, DateTimeKind.Local).AddTicks(6090), new DateTime(2021, 12, 21, 15, 56, 0, 329, DateTimeKind.Local).AddTicks(2835) });

            migrationBuilder.UpdateData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address_Country", "Address_Street" },
                values: new object[] { "Srbija", "Tolstojeva 5" });

            migrationBuilder.UpdateData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address_City", "Address_Country", "Address_Street" },
                values: new object[] { "Beograd", "Srbija", "Balzakova 31" });

            migrationBuilder.UpdateData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApiKey", "Address_City", "Address_Country", "Address_Street" },
                values: new object[] { "gasic", "Subotica", "Srbija", "Cara Dusana 56" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Drugstores");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Drugstores",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Drugstores",
                newName: "Address");

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 12, 18, 870, DateTimeKind.Local).AddTicks(5104), new DateTime(2021, 12, 21, 15, 12, 18, 866, DateTimeKind.Local).AddTicks(8054) });

            migrationBuilder.UpdateData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "Tolstojeva 3");

            migrationBuilder.UpdateData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City" },
                values: new object[] { "Tolstojeva 3", "Novi Sad" });

            migrationBuilder.UpdateData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "ApiKey", "City" },
                values: new object[] { "Tolstojeva 3", "nestorandom", "Novi Sad" });
        }
    }
}
