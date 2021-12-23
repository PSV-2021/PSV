using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class DataRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "DrugstoreOffers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "DrugstoreOffers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "DrugstoreOffers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "DrugstoreOffers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 56, 0, 331, DateTimeKind.Local).AddTicks(6090), new DateTime(2021, 12, 21, 15, 56, 0, 329, DateTimeKind.Local).AddTicks(2835) });
        }
    }
}
