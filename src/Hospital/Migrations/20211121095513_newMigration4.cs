using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class newMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergenId",
                table: "MedicalRecords");

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 55, 12, 823, DateTimeKind.Local).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 55, 12, 825, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 55, 12, 825, DateTimeKind.Local).AddTicks(9740));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllergenId",
                table: "MedicalRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 40, 29, 215, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 40, 29, 218, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 40, 29, 218, DateTimeKind.Local).AddTicks(248));
        }
    }
}
